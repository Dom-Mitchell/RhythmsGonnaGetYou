RecordsDatabase

-- Day 1 of Rhythm's GGY (ERD)
-- Explorer Mode Step (1-16) Done!

-- Step 1
createdb RecordsDatabase

-- Step 2
pgcli RecordsDatabase

-- Step 3
CREATE TABLE "Albums" ("Id" SERIAL PRIMARY KEY, "Title" TEXT, "IsExplicit" BOOLEAN, "ReleaseDate" DATE, "BandId" INTEGER NULL REFERENCES "Bands" ("Id"));

-- Step 4
ALTER TABLE "Bands" ADD CONSTRAINT Bands_Pk PRIMARY KEY (Id, Style);

CREATE TABLE "Bands" ("Id" SERIAL PRIMARY KEY, "Name" TEXT, "CountryOfOrigin" TEXT, "NumberOfMembers" INTEGER, "Website" TEXT, "Style" TEXT, "IsSigned" BOOLEAN, "ContactName" TEXT, "ContactPhoneNumber" VARCHAR(26));

-- Step 5
CREATE TABLE "Songs" ("Id" SERIAL PRIMARY KEY, "Title" TEXT, "Duration" TIME, "TrackNumber" INT, "AlbumId" INTEGER NULL REFERENCES "Albums" ("Id"));

-- Step 6 (Relationship between Entities)
ALTER TABLE "Bands" ADD COLUMN "AlbumId" INTEGER NULL REFERENCES "Albums" ("Id");

-- Step 7
INSERT INTO "Bands" ("Id", "Name", "CountryOfOrigin", "NumberOfMembers", "Website", "Style", "IsSigned", "ContactName", "ContactPhoneNumber"); 
VALUE (1, 'Juice WRLD', 'USA', 1, 'https://999club.com/', 'Hip-Hop/Rap', 'True', 'Jarad Higgins', '123-456-7890');

-- Step 8
SELECT * From "Bands";

-- Step 9
INSERT INTO "Albums" ("Id", "Title", "IsExplicit", "ReleaseDate")
VALUES (1, 'Legends Never Die', 'True', '07-10-2020');

-- Step 10
INSERT INTO "Songs" ("Id", "TrackNumber", "Title", "Duration")
VALUES (1, 3, 'Titanic', '2:57');

-- Step 11
UPDATE "Bands" SET "IsSigned" = 'False' WHERE "Name" = 'Juice WRLD';

-- Step 12
UPDATE "Bands" SET "IsSigned" = 'True' WHERE "Name" = 'Juice WRLD';

-- Step 13
SELECT "Albums"."Title" FROM "Albums" JOIN "Bands" ON "Albums"."Id" = "Bands"."Id" WHERE "Bands"."Name" = 'Juice WRLD';

-- Step 14
SELECT * FROM "Albums" ORDER BY "ReleaseDate";

-- Step 15
SELECT "Name" FROM "Bands" WHERE "IsSigned" = 'True';

-- Step 16
SELECT "Name" FROM "Bands" WHERE "IsSigned" = 'False';