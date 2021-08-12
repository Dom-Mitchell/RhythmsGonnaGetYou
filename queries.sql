RecordsDatabase

-- Day 1 of Rhythm's GGY (ERD)

-- Step 1
createdb RecordsDatabase

-- Step 2
pgcli RecordsDatabase

-- Step 3
CREATE TABLE "Albums" ("Id" SERIAL PRIMARY KEY, "Title" TEXT, "Genre" TEXT, "IsExplicit" BOOLEAN, "ReleaseDate" DATE);

-- Step 4
CREATE TABLE "Bands" ("Id" SERIAL PRIMARY KEY, "Name" TEXT, "CountryOfOrigin" TEXT, "Website" TEXT, "Style" TEXT, "IsSigned" BOOLEAN, "ContactName" TEXT, "ContactPhoneNumber" VARCHAR(10));

-- Step 5
CREATE TABLE "Songs" ("Id" SERIAL PRIMARY KEY, "TrackNumber" INT, "Title" TEXT, "Duration" TIME,);

-- Step 6
