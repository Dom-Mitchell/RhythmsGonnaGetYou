CREATE TABLE "Musicians" (
"Id" SERIAL PRIMARY KEY,
"Name" TEXT,
"Age" INT,
"Instrument" TEXT,
"CurrentMember" BOOLEAN,
"BandId" INTEGER NULL REFERENCES "Bands" ("Id")
);

CREATE TABLE "Concerts" (
"Id" SERIAL PRIMARY KEY,
"Place" TEXT,
"Date" DATE,
"BandId" INTEGER NULL REFERENCES "Bands" ("Id")
);