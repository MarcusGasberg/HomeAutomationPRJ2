library ieee;
use ieee.std_logic_1164.all;

entity code_lock_simple is 
	port(clk, reset, enter: in std_logic;
		  code: std_logic_vector(3 downto 0);
		  lock: out std_logic;	--Actual lock: Connected to GPIO pin.
		  lock3: out std_logic; --Projekt addition: Red light. 
		  lock2: out std_logic 	-- Projekt addition: Green light
		  );
end code_lock_simple;

architecture simple_lock of code_lock_simple is
	type state is (Idle, Evaluating_code_1, Getting_code_2, 
						Evaluating_code_2, Unlocked, Going_idle);
	signal present_state, next_state: state;
	
		begin 			
			--State register proces
			state_reg: process (clk, reset)
			begin 
				if (reset = not'1')then 
					present_state <= Idle;
				elsif rising_edge(clk)then
					present_state <= next_state;
				end if;
			end process;
			
			
			--Næste state proces
			next_state_process: process (present_state, code, enter)
			--Hardcoded code-variables. 
			variable code1, code2: std_logic_vector(3 downto 0);
			begin
				code1:= "0001";
				code2:= "0010";
				next_state <= present_state;
				
				case present_state is
				--Når vi Idle og trykker Enter, evaluater vi code1. 
					when Idle => 
						if (enter = '0')then -- active low key omvendt
							next_state <= Evaluating_code_1;
						end if;
						
					when Evaluating_code_1 => 
						if (enter = '1')then  
							if (code = code1)then
								next_state <= Getting_code_2;
							else 
								next_state <= Idle;
							end if;
						end if;
					
					when Getting_code_2 => 
						if (enter = '0')then 
							next_state <= Evaluating_code_2;
						end if;
						
					when Evaluating_code_2 => 
						if (enter ='1')then 
							if(code = code2) then 
							next_state <= Unlocked; 
							else 
								next_state <= Idle;
							end if;
						end if;
						
					when Unlocked => 
						if (enter = '0')then 
							next_state <= Going_idle;
						end if;
					
					when Going_idle => 
						if (enter = '1')then 
							next_state <= Idle;
						end if;
					end case;
				end process;
				
				outputs: process (present_state, code)
				begin 
					case present_state is
					
					--Der er kun låst op når vi er i Unlocked state
						when Unlocked => 
							lock <= '0';
							lock2<= not'0';
							lock3 <= '0';
						when others => 
							lock <=  '1';
							lock2 <= not'1'; 
							lock3 <= '1';
					end case;
				end process; 
end architecture;

						