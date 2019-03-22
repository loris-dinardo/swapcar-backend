----------------------------------- Create com schema

DROP SCHEMA IF EXISTS com CASCADE;
CREATE SCHEMA com;

----------------------------------- Create com sequences

DROP SEQUENCE IF EXISTS com.search_seq CASCADE;
CREATE SEQUENCE com.search_seq
	   INCREMENT BY 1
	   MINVALUE 0
	   MAXVALUE 9223372036854775807
	   START WITH 1
	   CACHE 1
	   NO CYCLE
	   OWNED BY NONE;
	   
DROP SEQUENCE IF EXISTS com.sell_seq CASCADE;
CREATE SEQUENCE com.sell_seq
	   INCREMENT BY 1
	   MINVALUE 0
	   MAXVALUE 9223372036854775807
	   START WITH 1
	   CACHE 1
	   NO CYCLE
	   OWNED BY NONE;
	   
DROP SEQUENCE IF EXISTS com.trade_in_seq CASCADE;
CREATE SEQUENCE com.trade_in_seq
	   INCREMENT BY 1
	   MINVALUE 0
	   MAXVALUE 9223372036854775807
	   START WITH 1
	   CACHE 1
	   NO CYCLE
	   OWNED BY NONE;
	   
-------------------------------------------------- Create com tables
-- Searchs
DROP TABLE IF EXISTS com.search CASCADE;
CREATE TABLE com.search(
			 search_id int4 NOT NULL DEFAULT nextval('com.search_seq'::regclass),
			 user_id int4,
			 brand_id int4, 
			 model_id int4,
			 version_id int4,
			 price_from integer,
			 price_to integer,
			 build_year_from integer,
			 build_year_to integer,
			 mileage_from integer,
			 mileage_to integer,
			 creation_date timestamp with time zone,
CONSTRAINT   search_pkey PRIMARY KEY (search_id)
);

-- Sells
DROP TABLE IF EXISTS com.sell CASCADE;
CREATE TABLE com.sell(
			 sell_id int4 NOT NULL DEFAULT nextval('com.sell_seq'::regclass),
			 user_id int4,
			 brand_id int4, 
			 model_id int4,
			 version_id int4,
			 price integer,
			 build_year integer,
			 mileage integer,
			 creation_date timestamp with time zone,
CONSTRAINT	 sell_pkey PRIMARY KEY (sell_id)
);

-- Trades In
DROP TABLE IF EXISTS com.trade_in CASCADE;
CREATE TABLE com.trade_in(
			 trade_in_id int4 NOT NULL DEFAULT nextval('com.trade_in_seq'::regclass),
			 search_id int4,
			 sell_id int4,
			 creation_date timestamp with time zone,
CONSTRAINT	 trade_in_pkey PRIMARY KEY (trade_in_id)
);

-------------------------------------------------- Create com constraints
-- Search on User
ALTER TABLE com.search
ADD CONSTRAINT search_user_fkey
FOREIGN KEY (user_id)
REFERENCES auth.user(user_id)
ON DELETE CASCADE;

-- Search on Car Brand
ALTER TABLE com.search
ADD CONSTRAINT search_brand_fkey
FOREIGN KEY (brand_id)
REFERENCES brand.brand(brand_id)
ON DELETE SET NULL;

-- Search on Car Model
ALTER TABLE com.search
ADD CONSTRAINT search_model_fkey
FOREIGN KEY (model_id)
REFERENCES brand.model(model_id)
ON DELETE SET NULL;

-- Search on Car Version
ALTER TABLE com.search
ADD CONSTRAINT search_version_fkey
FOREIGN KEY (version_id)
REFERENCES brand.version(version_id)
ON DELETE SET NULL;

-- Sell on User
ALTER TABLE com.sell
ADD CONSTRAINT sell_user_fkey
FOREIGN KEY (user_id)
REFERENCES auth.user(user_id)
ON DELETE CASCADE;

-- Sell on Car Brand
ALTER TABLE com.sell
ADD CONSTRAINT sell_brand_fkey
FOREIGN KEY (brand_id)
REFERENCES brand.brand(brand_id)
ON DELETE SET NULL;

-- Sell on Car Model
ALTER TABLE com.sell
ADD CONSTRAINT sell_model_fkey
FOREIGN KEY (model_id)
REFERENCES brand.model(model_id)
ON DELETE SET NULL;

-- Sell on Car Version
ALTER TABLE com.sell
ADD CONSTRAINT sell_version_fkey
FOREIGN KEY (version_id)
REFERENCES brand.version(version_id)
ON DELETE SET NULL;

-- Trade In on Search
ALTER TABLE com.trade_in
ADD CONSTRAINT trade_in_search_fkey
FOREIGN KEY (search_id)
REFERENCES com.search(search_id)
ON DELETE CASCADE;

-- Trade In on Sell
ALTER TABLE com.trade_in
ADD CONSTRAINT trade_in_sell_fkey
FOREIGN KEY (sell_id)
REFERENCES com.sell(sell_id)
ON DELETE CASCADE;