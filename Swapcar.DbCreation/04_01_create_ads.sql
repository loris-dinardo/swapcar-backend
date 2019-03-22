----------------------------------- Create ads schema

DROP SCHEMA IF EXISTS ads CASCADE;
CREATE SCHEMA ads;

----------------------------------- Create ads sequences

DROP SEQUENCE IF EXISTS ads.ads_seq CASCADE;
CREATE SEQUENCE ads.ads_seq
	   INCREMENT BY 1
	   MINVALUE 0
	   MAXVALUE 9223372036854775807
	   START WITH 1
	   CACHE 1
	   NO CYCLE
	   OWNED BY NONE;
	   
-------------------------------------------------- Create ads tables
-- Ads
DROP TABLE IF EXISTS ads.ads CASCADE;
CREATE TABLE ads.ads(
			 ads_id int4 NOT NULL DEFAULT nextval('ads.ads_seq'::regclass),
			 user_id int4,
			 search_id int4,
			 sell_id int4,
			 trade_in_id int4,
			 title varchar(255), 
			 image_uri varchar(255),
			 advert_from timestamp with time zone,
			 advert_to timestamp with time zone,
			 creation_date timestamp with time zone,
CONSTRAINT   ads_pkey PRIMARY KEY (user_id)
);

-------------------------------------------------- Create ads constraints
-- Ads on User
ALTER TABLE ads.ads
ADD CONSTRAINT ads_user_fkey
FOREIGN KEY (user_id)
REFERENCES auth.user(user_id)
ON DELETE CASCADE;

-- Ads on Search
ALTER TABLE ads.ads
ADD CONSTRAINT ads_search_fkey
FOREIGN KEY (search_id)
REFERENCES com.search(search_id)
ON DELETE SET NULL;

-- Ads on Sell
ALTER TABLE ads.ads
ADD CONSTRAINT ads_sell_fkey
FOREIGN KEY (sell_id)
REFERENCES com.sell(sell_id)
ON DELETE SET NULL;

-- Ads on Trade In
ALTER TABLE ads.ads
ADD CONSTRAINT ads_trade_in_fkey
FOREIGN KEY (trade_in_id)
REFERENCES com.trade_in(trade_in_id)
ON DELETE SET NULL;