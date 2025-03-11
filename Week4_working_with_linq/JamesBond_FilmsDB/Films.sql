DROP TABLE IF EXISTS Films;

CREATE TABLE Films(
    FilmID INTEGER PRIMARY KEY,
    Title VARCHAR(50),
    Year INTEGER,
	ActorID INTEGER 
);

INSERT INTO 
    Films (Title, Year, ActorID) 
VALUES 
	('Casino Royale', 2006, 6),
	('Diamonds Are Forever', 1971, 1),
	('Die Another Day', 2002, 5),
	('Dr. No', 1962, 1),
	('For Your Eyes Only', 1981,4),
	('From Russia with Love', 1963, 1),
	('GoldenEye', 1995, 5), 
	('Goldfinger', 1964, 1), 
	('Licence to Kill', 1989, 3),
	('Live and Let Die', 1973, 4),
	('Living Daylights', 1987, 3),
	('Man with the Golden Gun', 1974, 4),
	('Moonraker', 1979, 4),
	('No Time to Die', 2021, 6),
	('Octopussy', 1983, 4),
	('On Her Majesty''s Secret Service', 1969, 2),
	('Quantum of Solace', 2008, 6),
	('Skyfall', 2012, 6),
	('Spectre', 2015, 6),
	('Spy Who Loved Me', 1977, 4),
	('Thunderball', 1965, 1),
	('Tomorrow Never Dies', 1997, 5),
	('View to a Kill', 1985, 4),
	('World Is Not Enough', 1999, 5),
	('You Only Live Twice', 1967, 1);

 
DROP TABLE IF EXISTS Actors;

CREATE TABLE Actors(
    ActorID INTEGER PRIMARY KEY,
    Firstname VARCHAR(50),
    Lastname  VARCHAR(50)
); 

INSERT INTO 
    Actors (Firstname, Lastname) 
VALUES 
	('Sean', 'Connery'),
	('George', 'Lazenby'),
	('Roger', 'Moore'),
	('Timothy', 'Dalton'),
	('Pierce', 'Brosnan'),
	('Daniel', 'Craig'); */
