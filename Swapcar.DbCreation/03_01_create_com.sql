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
			 name varchar(255), 
CONSTRAINT   search_pkey PRIMARY KEY (search_id)
);

-- Sells
DROP TABLE IF EXISTS com.sell CASCADE;
CREATE TABLE com.sell(
			 sell_id int4 NOT NULL DEFAULT nextval('com.sell_seq'::regclass),
			 name varchar(255), 
CONSTRAINT	 sell_pkey PRIMARY KEY (sell_id)
);

-- Trades In
DROP TABLE IF EXISTS com.trade_in CASCADE;
CREATE TABLE com.trade_in(
			 trade_in_id int4 NOT NULL DEFAULT nextval('com.trade_in_seq'::regclass),
			 name varchar(255),
			 search_id int4,
			 sell_id int4,
CONSTRAINT	 trade_in_pkey PRIMARY KEY (trade_in_id)
);

-------------------------------------------------- Create com constraints
-- Trade In on Search
ALTER TABLE com.trade_in
ADD CONSTRAINT sell_fkey
FOREIGN KEY (search_id)
REFERENCES com.search(search_id)
ON DELETE CASCADE;

-- Trade In on Sell
ALTER TABLE com.trade_in
ADD CONSTRAINT sell_fkey
FOREIGN KEY (sell_id)
REFERENCES com.sell(sell_id)
ON DELETE CASCADE;