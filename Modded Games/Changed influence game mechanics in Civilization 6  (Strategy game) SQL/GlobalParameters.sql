/*
	Author: totalslacker
	Release Date: 3/14/2018

	EXPLANATION:
	
	1. CAPITAL_IDENTITY_PRESSURE_TILE_RADIUS_MAXIUMUM_BASE
	
	Default value in the base game is 10.  Default mod value is 6.  This number
	represents the number of tiles that pressure will extend from the capital city,
	including the tile that contains the capital city itself.  Capital cities
	generate extra pressure on top of other cities so this value can stack with
	the value below.
	
	2. CITIZEN_IDENTITY_PRESSURE_RADIUS_CUTOFF
	
	Default value in the base game is 10.  Default mod value is 6.  This number
	represents the number of tiles that pressure will extend from any given
	city that is not the capital, including the tile that contains the city itself.
	
	3. LOYALTY_PER_TURN_FROM_NEARBY_CITIZEN_PRESSURE_MAX_LOYALTY
	
	Default value in the base game is 20.  Default mod value is 10.  This number
	represents the maximum possible pressure that can be exerted on any one tile.
	Not all tiles will reach the maximum pressure, as pressure decreases with 
	distance from the source.
	
	TO MAKE CHANGES:
	
	Alter the number inside the parentheses in front of: 
	
						set Value = "__" <--insert number here below
	
	Be careful with LOYALTY_PER_TURN_FROM_NEARBY_CITIZEN_PRESSURE_MAX_LOYALTY.
	Some values seem to make the game crash, possibly due to math errors when calculating
	the loyalty to distance ratio.  Recommend sticking with even multiples of 5 (5,10,15, etc)
	You can set these values to greater than the game defaults if you wish for larger maps.
*/

INSERT OR REPLACE INTO GlobalParameters (Name, Value) VALUES ('CAPITAL_IDENTITY_PRESSURE_TILE_RADIUS_MAXIUMUM_BASE', 		'6');
INSERT OR REPLACE INTO GlobalParameters (Name, Value) VALUES ('CITIZEN_IDENTITY_PRESSURE_RADIUS_CUTOFF', 					'6');
INSERT OR REPLACE INTO GlobalParameters (Name, Value) VALUES ('LOYALTY_PER_TURN_FROM_NEARBY_CITIZEN_PRESSURE_MAX_LOYALTY', 	'10');