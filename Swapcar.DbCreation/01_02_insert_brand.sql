-- type: INSERT
-- user: LD
-- created: 20/3/2019

-- BRAND
INSERT INTO brand.brand VALUES ( 1,'VW');
INSERT INTO brand.brand VALUES ( 2,'FIAT');
INSERT INTO brand.brand VALUES ( 3,'FORD');

-- MODEL
INSERT INTO brand.model VALUES ( 1,'POLO',1);
INSERT INTO brand.model VALUES ( 2,'GOLF',1);
INSERT INTO brand.model VALUES ( 3,'UNO',2);
INSERT INTO brand.model VALUES ( 4,'PANDA',2);
INSERT INTO brand.model VALUES ( 5,'MUSTANG',3);
INSERT INTO brand.model VALUES ( 6,'FOCUS',3);

-- VERSION
INSERT INTO brand.version VALUES ( 1,'Blue Motion, 1.4, 60Cv',1);
INSERT INTO brand.version VALUES ( 2,'Blue Motion, 1.6, 90Cv',1);
INSERT INTO brand.version VALUES ( 3,'Golf 6, 1.6, 90Cv',2);
INSERT INTO brand.version VALUES ( 4,'Golf 6, 2.0, 120Cv',2);
INSERT INTO brand.version VALUES ( 5,'Uno, 1.0, 30Cv',3);
INSERT INTO brand.version VALUES ( 6,'Uno, 1.2, 45Cv',3);
INSERT INTO brand.version VALUES ( 7,'Panda, 1.4, 60Cv',4);
INSERT INTO brand.version VALUES ( 8,'Panda, 1.6, 90Cv',4);
INSERT INTO brand.version VALUES ( 9,'Shelbi, 3.6, 390Cv',5);
INSERT INTO brand.version VALUES ( 10,'GT, 2.6, 250Cv',5);
INSERT INTO brand.version VALUES ( 11,'ST, 2.0, 150Cv',6);
INSERT INTO brand.version VALUES ( 12,'RS, 2.4, 200Cv',6);

