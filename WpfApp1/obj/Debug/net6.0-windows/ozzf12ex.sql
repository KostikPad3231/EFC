﻿CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;

CREATE TABLE "Users" (
    "Username" text NOT NULL,
    "Password" text NOT NULL,
    CONSTRAINT "PK_Users" PRIMARY KEY ("Username")
);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20231114114819_AddUser', '7.0.13');

COMMIT;

START TRANSACTION;

CREATE TABLE "Topics" (
    "Id" integer GENERATED BY DEFAULT AS IDENTITY,
    "CreatedAt" timestamp with time zone NOT NULL DEFAULT (NOW()),
    "UserUsername" text NOT NULL,
    CONSTRAINT "PK_Topics" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Topics_Users_UserUsername" FOREIGN KEY ("UserUsername") REFERENCES "Users" ("Username") ON DELETE CASCADE
);

CREATE TABLE "Posts" (
    "Id" integer GENERATED BY DEFAULT AS IDENTITY,
    "Message" text NOT NULL,
    "UpdatedAt" timestamp with time zone NOT NULL,
    "TopicId" integer NOT NULL,
    "UserUsername" text NOT NULL,
    CONSTRAINT "PK_Posts" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Posts_Topics_TopicId" FOREIGN KEY ("TopicId") REFERENCES "Topics" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_Posts_Users_UserUsername" FOREIGN KEY ("UserUsername") REFERENCES "Users" ("Username") ON DELETE CASCADE
);

CREATE INDEX "IX_Posts_TopicId" ON "Posts" ("TopicId");

CREATE INDEX "IX_Posts_UserUsername" ON "Posts" ("UserUsername");

CREATE INDEX "IX_Topics_UserUsername" ON "Topics" ("UserUsername");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20231114114832_AddTopicAndPost', '7.0.13');

COMMIT;

START TRANSACTION;

ALTER TABLE "Topics" ADD "Name" text NOT NULL DEFAULT '';

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20231114125510_AddNameColumnToTopics', '7.0.13');

COMMIT;

START TRANSACTION;

ALTER TABLE "Posts" ALTER COLUMN "UpdatedAt" SET DEFAULT (NOW());

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20231114194522_AddDefaultDateTimeToCreatedAtAtPost', '7.0.13');

COMMIT;

START TRANSACTION;

ALTER TABLE "Posts" DROP CONSTRAINT "FK_Posts_Users_UserUsername";

ALTER TABLE "Topics" DROP CONSTRAINT "FK_Topics_Users_UserUsername";

ALTER TABLE "Users" DROP CONSTRAINT "PK_Users";

DROP INDEX "IX_Topics_UserUsername";

DROP INDEX "IX_Posts_UserUsername";

ALTER TABLE "Users" ADD "Id" integer GENERATED BY DEFAULT AS IDENTITY;

ALTER TABLE "Topics" ADD "UserId" integer NULL;

ALTER TABLE "Posts" ADD "UserId" integer NULL;

ALTER TABLE "Users" ADD CONSTRAINT "PK_Users" PRIMARY KEY ("Id");

CREATE INDEX "IX_Topics_UserId" ON "Topics" ("UserId");

CREATE INDEX "IX_Posts_UserId" ON "Posts" ("UserId");

ALTER TABLE "Posts" ADD CONSTRAINT "FK_Posts_Users_UserId" FOREIGN KEY ("UserId") REFERENCES "Users" ("Id");

ALTER TABLE "Topics" ADD CONSTRAINT "FK_Topics_Users_UserId" FOREIGN KEY ("UserId") REFERENCES "Users" ("Id");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20231114203235_AddIdAsPKToUser', '7.0.13');

COMMIT;

START TRANSACTION;

ALTER TABLE "Posts" DROP CONSTRAINT "FK_Posts_Users_UserId";

ALTER TABLE "Topics" DROP CONSTRAINT "FK_Topics_Users_UserId";

ALTER TABLE "Topics" DROP COLUMN "UserUsername";

ALTER TABLE "Posts" DROP COLUMN "UserUsername";

UPDATE "Topics" SET "UserId" = 0 WHERE "UserId" IS NULL;
ALTER TABLE "Topics" ALTER COLUMN "UserId" SET NOT NULL;
ALTER TABLE "Topics" ALTER COLUMN "UserId" SET DEFAULT 0;

UPDATE "Posts" SET "UserId" = 0 WHERE "UserId" IS NULL;
ALTER TABLE "Posts" ALTER COLUMN "UserId" SET NOT NULL;
ALTER TABLE "Posts" ALTER COLUMN "UserId" SET DEFAULT 0;

CREATE UNIQUE INDEX "IX_Users_Username" ON "Users" ("Username");

ALTER TABLE "Posts" ADD CONSTRAINT "FK_Posts_Users_UserId" FOREIGN KEY ("UserId") REFERENCES "Users" ("Id") ON DELETE CASCADE;

ALTER TABLE "Topics" ADD CONSTRAINT "FK_Topics_Users_UserId" FOREIGN KEY ("UserId") REFERENCES "Users" ("Id") ON DELETE CASCADE;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20231115091145_ChangeFKsInPostAndTopic', '7.0.13');

COMMIT;

