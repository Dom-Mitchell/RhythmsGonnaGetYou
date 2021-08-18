-- Copy These Commands to Quickly Test Project

-- Step 1
createdb RecordsDatabase

-- Step 2
pgcli RecordsDatabase

-- Step 3
CREATE TABLE "Bands" 
(
  "Id" SERIAL PRIMARY KEY, 
  "Name" TEXT, 
  "CountryOfOrigin" TEXT, 
  "NumberOfMembers" INTEGER, 
  "Website" VARCHAR(67), 
  "Style" TEXT, 
  "IsSigned" BOOLEAN, 
  "ContactName" TEXT, 
  "ContactPhoneNumber" VARCHAR(16)
);

-- Step 4
CREATE TABLE "Albums" 
(
  "Id" SERIAL PRIMARY KEY, 
  "Title" TEXT, 
  "IsExplicit" BOOLEAN, 
  "ReleaseDate" DATE, 
  "BandId" INTEGER NULL REFERENCES "Bands" ("Id")
);

-- Step 5
CREATE TABLE "Songs" 
(
  "Id" SERIAL PRIMARY KEY, 
  "Title" TEXT, 
  "Duration" TIME, 
  "TrackNumber" INT, 
  "AlbumId" INTEGER NULL REFERENCES "Albums" ("Id")
);

-- Step 6
CREATE TABLE "Musicians" 
(
"Id" SERIAL PRIMARY KEY,
"Name" TEXT,
"Age" INT,
"Instrument" TEXT,
"CurrentMember" BOOLEAN,
"BandId" INTEGER NULL REFERENCES "Bands" ("Id")
);

-- Step 7
CREATE TABLE "Concerts" 
(
"Id" SERIAL PRIMARY KEY,
"Place" TEXT,
"Date" DATE,
"BandId" INTEGER NULL REFERENCES "Bands" ("Id")
);

-- Step 8
INSERT INTO "Bands" ("Id", "Name", "CountryOfOrigin", "NumberOfMembers", "Website", "Style", "IsSigned", "ContactName", "ContactPhoneNumber"); 
VALUE (1, 'Juice WRLD', 'Argentina', 1, '123.com', 'Rap', 'True', 'Juice', '+1(123)-456-7890');

-- Step 9
INSERT INTO "Bands" ("Id", "Name", "CountryOfOrigin", "NumberOfMembers", "Website", "Style", "IsSigned", "ContactName", "ContactPhoneNumber"); 
VALUE (2, 'licked wood chip', 'North Korea', 28, 'google.com', 'Electronic Dance Music', 'True', 'Joe Biden', '+1(813)-926-7653');

-- Step 10
INSERT INTO "Bands" ("Id", "Name", "CountryOfOrigin", "NumberOfMembers", "Website", "Style", "IsSigned", "ContactName", "ContactPhoneNumber"); 
VALUE (3, 'jonny cash', 'Madagascar', 3, 'yahoo.com', 'Rap', 'False', 'jon-jon', '+1(123)-456-7890');

-- Step 11
INSERT INTO "Bands" ("Id", "Name", "CountryOfOrigin", "NumberOfMembers", "Website", "Style", "IsSigned", "ContactName", "ContactPhoneNumber"); 
VALUE (4, 'chicin', 'Russia', 100, 'bobross.com', 'World', 'True', 'bob', '+1(496)-000-0000');

-- Step 12
INSERT INTO "Albums" ("Id", "Title", "IsExplicit", "ReleaseDate", "BandId")
VALUES (1, 'Danny & Da Bois', 'True', '2021-08-16', 1);

-- Step 13
INSERT INTO "Albums" ("Id", "Title", "IsExplicit", "ReleaseDate", "BandId")
VALUES (1, 'j', 'True', '1412-12-03', 3);

-- Step 14
INSERT INTO "Songs" ("Id", "Title",  "Duration", "TrackNumber", "AlbumId")
VALUES (1, "Money Longer", '02:30:00', 8, 1);

-- Step 15
INSERT INTO "Songs" ("Id", "Title",  "Duration", "TrackNumber", "AlbumId")
VALUES (2, "Titanic", '12:30:00', 3, 2);

-- Step 16
INSERT INTO "Musicians" ("Id", "Name",  "Age", "Instrument", "CurrentMember", "BandId")
VALUES (1, "Juice WRLD", "21", "Vocalist", "True", 1);

-- Step 17
INSERT INTO "Musicians" ("Id", "Name",  "Age", "Instrument", "CurrentMember", "BandId")
VALUES (2, "Juicy j", "18", "Tuba", "False", 1);

-- Step 18
INSERT INTO "Concerts" ("Id", "Place", "Date", "BandId")
VALUES (1, "Disney", '2021-08-18', 1);