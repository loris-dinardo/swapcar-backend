----------------------------------- Create brand schema

DROP SCHEMA IF EXISTS brand CASCADE;
CREATE SCHEMA brand;

----------------------------------- Create brand sequences

DROP SEQUENCE IF EXISTS brand.brand_seq CASCADE;
CREATE SEQUENCE brand.brand_seq
	   INCREMENT BY 1
	   MINVALUE 0
	   MAXVALUE 9223372036854775807
	   START WITH 1
	   CACHE 1
	   NO CYCLE
	   OWNED BY NONE;
	   
DROP SEQUENCE IF EXISTS brand.model_seq CASCADE;
CREATE SEQUENCE brand.model_seq
	   INCREMENT BY 1
	   MINVALUE 0
	   MAXVALUE 9223372036854775807
	   START WITH 1
	   CACHE 1
	   NO CYCLE
	   OWNED BY NONE;
	   
DROP SEQUENCE IF EXISTS brand.version_seq CASCADE;
CREATE SEQUENCE brand.version_seq
	   INCREMENT BY 1
	   MINVALUE 0
	   MAXVALUE 9223372036854775807
	   START WITH 1
	   CACHE 1
	   NO CYCLE
	   OWNED BY NONE;
	   
-------------------------------------------------- Create brand tables
-- Car Brands
DROP TABLE IF EXISTS brand.brand CASCADE;
CREATE TABLE brand.brand(
			 brand_id int4 NOT NULL DEFAULT nextval('brand.brand_seq'::regclass),
			 name varchar(255), 
CONSTRAINT   brand_pkey PRIMARY KEY (brand_id)
);

-- Car Models
DROP TABLE IF EXISTS brand.model CASCADE;
CREATE TABLE brand.model(
			 model_id int4 NOT NULL DEFAULT nextval('brand.model_seq'::regclass),
			 name varchar(255), 
			 brand_id int4,
CONSTRAINT	 model_pkey PRIMARY KEY (model_id),
CONSTRAINT	 brand_fkey FOREIGN KEY (brand_id) REFERENCES brand.brand(brand_id)
);

-- Car Versions
DROP TABLE IF EXISTS brand.version CASCADE;
CREATE TABLE brand.version(
			 version_id int4 NOT NULL DEFAULT nextval('brand.version_seq'::regclass),
			 name varchar(255),
			 model_id int4,
CONSTRAINT	 version_pkey PRIMARY KEY (version_id),
CONSTRAINT	 model_fkey FOREIGN KEY (model_id) REFERENCES brand.model(model_id)
);