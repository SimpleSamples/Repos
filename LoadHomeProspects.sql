BEGIN TRANSACTION;
CREATE TABLE "HomeProspects" (
	Id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	"CId"	INTEGER not null,
	"Community"	TEXT,
	"OnM"	Date not null,
	"Ask"	INTEGER not null,
	"SqFt"	INTEGER,
	"LotSqFt"	INTEGER,
	"Beds"	INTEGER,
	"Address"	TEXT not null,
	"Comments"	TEXT
);
INSERT INTO "HomeProspects" VALUES (1,'Desert Crest Community Association','2/5/2020',40,600,'3000',2,'16831 Sunrise Rd, Desert Hot Springs, CA 92241','Has tenant');
INSERT INTO "HomeProspects" VALUES (1,'Desert Crest Community Association','1/16/2020',78,900,'3250',3,'69431 Midpark Dr, Desert Hot Springs, CA 92241',NULL);
INSERT INTO "HomeProspects" VALUES (1,'Desert Crest Community Association','9/11/2019',80,775,'3920',2,'69290 Fairway Dr #6952, Desert Hot Springs, CA 92241',NULL);
INSERT INTO "HomeProspects" VALUES (2,'Ramrod Senior Housing Inc','8/15/2019',60,1340,NULL,2,'1010 Terrace Rd #147, Rialto, CA 92410',NULL);
INSERT INTO "HomeProspects" VALUES (3,'Sierra Dawn Estates Homeowners','1/31/2020',100,1368,'4356',2,'957 S Elk St, Hemet, CA 92543','Sale Pending');
INSERT INTO "HomeProspects" VALUES (3,'Sierra Dawn Estates Homeowners','1/26/2020',60,1891,'4356',3,'371 Santa Clara Cir, Hemet, CA 92543','Sale Pending');
INSERT INTO "HomeProspects" VALUES (3,'Sierra Dawn Estates Homeowners','1/14/2020',95,1040,'3485',2,'729 S Elk St, Hemet, CA 92543',NULL);
INSERT INTO "HomeProspects" VALUES (3,'Sierra Dawn Estates Homeowners','1/10/2020',85,1000,'3485',2,'691 Santa Clara Cir, Hemet, CA 92543',NULL);
INSERT INTO "HomeProspects" VALUES (3,'Sierra Dawn Estates Homeowners','10/1/2019',90,1224,'4356',2,'591 Santa Clara Cir, Hemet, CA 92543',NULL);
INSERT INTO "HomeProspects" VALUES (4,'Mountain Shadows RV Resort','10/23/2019',99,400,'2614',1,'1295 S Cawston Ave #147, Hemet, CA 92545',NULL);
INSERT INTO "HomeProspects" VALUES (4,'Mountain Shadows RV Resort','7/8/2019',80,799,'2614',1,'1295 S Cawston Ave #295, Hemet, CA 92545',NULL);
INSERT INTO "HomeProspects" VALUES (4,'Mountain Shadows RV Resort','8/28/2019',99,640,'2614',1,'1295 S Cawston Ave #141, Hemet, CA 92545','Sale Pending');
INSERT INTO "HomeProspects" VALUES (3,'Sierra Dawn Estates Homeowners','8/27/2019',81,1288,'4792',2,'585 Castille Dr, Hemet, CA 92543',NULL);
INSERT INTO "HomeProspects" VALUES (3,'Sierra Dawn Estates Homeowners','2/16/2020',88,1080,'3485',2,'821 San Rafael Dr, Hemet, CA 92543',NULL);
INSERT INTO "HomeProspects" VALUES (3,'Sierra Dawn Estates Homeowners','2/13/2020',99,1344,'4792',2,'741 San Mateo Cir, Hemet, CA 92543',NULL);
INSERT INTO "HomeProspects" VALUES (3,'Sierra Dawn Estates Homeowners','1/3/2020',85,817,'4356',2,'670 Santa Clara Cir, Hemet, CA 92543',NULL);
INSERT INTO "HomeProspects" VALUES (3,'Sierra Dawn Estates Homeowners','1/23/2020',50,480,'2614',1,'1295 S Cawston Ave #298, Hemet, CA 92545',NULL);
INSERT INTO "HomeProspects" VALUES (3,'Sierra Dawn Estates Homeowners','2/10/2020',80,500,'2178',1,'1295 S Cawston Ave #334, Hemet, CA 92545',NULL);
INSERT INTO "HomeProspects" VALUES (5,'Heritage Ranch Community Association','1/24/2020',70,700,'1742',1,'1427 Heritage Ranch Rd, San Jacinto, CA 92583',NULL);
INSERT INTO "HomeProspects" VALUES (5,'Heritage Ranch Community Association','2/18/2020',75,824,'1742',1,'1356 SIERRA Dr, San Jacinto, CA 92583','Tiny yard');
INSERT INTO "HomeProspects" VALUES (5,'Heritage Ranch Community Association','12/14/2019',65,604,'2178',1,'819 Acorn Dr, San Jacinto, CA 92583','Sale Pending');
INSERT INTO "HomeProspects" VALUES (5,'Heritage Ranch Community Association','1/11/2020',80,600,'2178',1,'1393 Frontier Ave, San Jacinto, CA 92583',NULL);
INSERT INTO "HomeProspects" VALUES (5,'Heritage Ranch Community Association','1/21/2020',77,705,'1742',1,'1478 Western Dr, San Jacinto, CA 92583',NULL);
INSERT INTO "HomeProspects" VALUES (6,'Tri Palm Estates','4/3/2019',80,686,'5663',2,'73083 Banff St, Thousand Palms, CA 92276',NULL);
INSERT INTO "HomeProspects" VALUES (6,'Tri Palm Estates','10/22/2019',99,1135,'5227',2,'73660 Algonquin Pl, Thousand Palms, CA 92276',NULL);
INSERT INTO "HomeProspects" VALUES (6,'Tri Palm Estates','7/24/2019',90,1008,'3920',2,'33183 Laura Dr, Thousand Palms, CA 92276',NULL);
INSERT INTO "HomeProspects" VALUES (6,'Tri Palm Estates','9/27/2019',83,784,'5227',2,'73581 Stanton Dr, Thousand Palms, CA 92276','Active Under Contract');
INSERT INTO "HomeProspects" VALUES (6,'Tri Palm Estates','12/2/2019',94,672,'4792',2,'32863 Sarasota Pl, Thousand Palms, CA 92276',NULL);
INSERT INTO "HomeProspects" VALUES (6,'Tri Palm Estates','6/29/2019',55,1350,'5000',2,'33820 Westchester Dr, Thousand Palms, CA 92276',NULL);
INSERT INTO "HomeProspects" VALUES (6,'Tri Palm Estates','2/21/2020',100,1344,'5663',3,'32391 Wells Fargo Rd, Thousand Palms, CA 92276',NULL);
INSERT INTO "HomeProspects" VALUES (1,'Desert Crest Community Association','2/21/2020',80,1080,'3920',2,'69261 Parkside Dr, Desert Hot Springs, CA 92241',NULL);
INSERT INTO "HomeProspects" VALUES (1,'Desert Crest Community Association','2/17/2020',85,846,NULL,2,'69371 Crestview, Desert Hot Springs, CA 92241',NULL);
INSERT INTO "HomeProspects" VALUES (1,'Desert Crest Community Association','2/17/2020',84,1163,'4792',2,'69480 Crestview Dr, Desert Hot Springs, CA 92241',NULL);
INSERT INTO "HomeProspects" VALUES (1,'Desert Crest Community Association','2/17/2020',97,1150,'3485',2,'69250 Midpark Dr, Desert Hot Springs, CA 92241',NULL);
INSERT INTO "HomeProspects" VALUES (3,'Sierra Dawn Estates','2/19/2020',80,960,'4792',2,'450 San Mateo Cir, Hemet, CA 92543',NULL);
INSERT INTO "HomeProspects" VALUES (6,'Tri Palm Estates','2/26/2020',80,800,'6250',2,'32735 St Andrews Dr, Thousand Palms, CA 92276','Pending');
INSERT INTO "HomeProspects" VALUES (5,'Heritage Ranch Community Association','2/20/2020',55,480,'1742',1,'1364 Sierra Dr, San Jacinto, CA 92583',NULL);
INSERT INTO "HomeProspects" VALUES (4,'Mountain Shadows','2/17/2020',85,400,'1742',1,'1295 S Cawston Ave #205, Hemet, CA 92545',NULL);
INSERT INTO "HomeProspects" VALUES (6,'Tri Palm Estates','11/12/2019',100,1700,'5227',2,'32380 San Miguelito Dr, Thousand Palms, CA 92276',NULL);
INSERT INTO "HomeProspects" VALUES (7,'Hacienda Trailer Park','2/27/2020',89,1351,'4356',3,'21752 Mesquite St #000, California City, CA 93505','Isolated, 13 miles from Mojave');
INSERT INTO "HomeProspects" VALUES (8,'Apache Mobile Home Park','11/5/2019',35,1130,NULL,3,'56254 29 Palms Hwy, Yucca Valley, CA 92284',NULL);
INSERT INTO "HomeProspects" VALUES (9,'Ramrod Senior Mobile Home Park','3/3/2020',100,1440,'1440',2,'1010 Terrace Rd #115, San Bernardino, CA 92410',NULL);
INSERT INTO "HomeProspects" VALUES (4,'Mountain Shadows','10/5/2019',85,480,'2178',1,'1295 S Cawston Ave #496, Hemet, CA 92545',NULL);
INSERT INTO "HomeProspects" VALUES (3,'Sierra Dawn Estates Homeowners','2/28/2020',90,716,'3485',2,'690 Santa Clara, Hemet, CA 92543',NULL);
INSERT INTO "HomeProspects" VALUES (5,'Heritage Ranch Community Association','3/3/2020',70,640,'1742',1,'1349 Sierra Dr, San Jacinto, CA 92583',NULL);
INSERT INTO "HomeProspects" VALUES (4,'Mountain Shadows','3/3/2020',95,580,'2178',1,'1295 S Cawston Ave #344, Hemet, CA 92545',NULL);
INSERT INTO "HomeProspects" VALUES (4,'Mountain Shadows','3/3/2020',70,665,'2178',1,'1295 S Cawston Ave #331, Hemet, CA 92545',NULL);
INSERT INTO "HomeProspects" VALUES (4,'Mountain Shadows','2/10/2020',80,500,'2178',1,'1295 S Cawston Ave #334, Hemet, CA 92545',NULL);
COMMIT;
