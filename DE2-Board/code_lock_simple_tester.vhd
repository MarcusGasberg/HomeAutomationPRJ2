library ieee;

use ieee.std_logic_1164.all;

use work.all;


entity code_lock_simple_tester is 

	port(

			CLOCK_50: in std_logic;

			KEY: in std_logic_vector (3 downto 2);

			SW: in std_logic_vector(3 downto 0);			
			
			GPIO_0: out std_logic_vector(0 downto 0);

			LEDG: out std_logic_vector (0 downto 0);

			LEDR: out std_logic_vector (0 downto 0)

		);

end code_lock_simple_tester;

architecture test of code_lock_simple_tester is 

	begin 

		

			codeLockSimple: entity code_lock_simple port map(

			clk => CLOCK_50,

			reset => KEY(2), 	--Reset is KEY2

			code => SW, 		-- Code is SW[4:0]

			enter => KEY(3), 	-- Enter is KEY3

			lock2 => LEDG(0), --LEDG0 green LED when unlocked. 

			lock => GPIO_0(0),--GPIO_0[0] connected to X.10Transmitter, low when unlocked. 

			lock3 => LEDR(0)  -- LEDR0 red LED when locked. 

		);

end test;