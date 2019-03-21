----------------------------------- Create auth schema

DROP SCHEMA IF EXISTS auth CASCADE;
CREATE SCHEMA auth;

----------------------------------- Create auth sequences

DROP SEQUENCE IF EXISTS auth.user_seq CASCADE;
CREATE SEQUENCE auth.user_seq
	   INCREMENT BY 1
	   MINVALUE 0
	   MAXVALUE 9223372036854775807
	   START WITH 1
	   CACHE 1
	   NO CYCLE
	   OWNED BY NONE;
	   
DROP SEQUENCE IF EXISTS auth.profile_seq CASCADE;
CREATE SEQUENCE auth.profile_seq
	   INCREMENT BY 1
	   MINVALUE 0
	   MAXVALUE 9223372036854775807
	   START WITH 1
	   CACHE 1
	   NO CYCLE
	   OWNED BY NONE;
	   
-------------------------------------------------- Create auth tables
-- Users
DROP TABLE IF EXISTS auth.user CASCADE;
CREATE TABLE auth.user(
			 user_id int4 NOT NULL DEFAULT nextval('auth.user_seq'::regclass),
			 email varchar(255), 
			 nickname varchar(255),
			 hash_password varchar(255),
			 salt varchar(255),
CONSTRAINT   user_pkey PRIMARY KEY (user_id)
);

-- Profiles
DROP TABLE IF EXISTS auth.profile CASCADE;
CREATE TABLE auth.profile(
			 profile_id int4 NOT NULL DEFAULT nextval('auth.profile_seq'::regclass),
			 firstname varchar(255), 
			 lastname varchar(255),
			 user_id int4,
CONSTRAINT	 profile_pkey PRIMARY KEY (profile_id)
);

-------------------------------------------------- Create auth constraints
-- Profiles
ALTER TABLE auth.profile
ADD CONSTRAINT user_fkey
FOREIGN KEY (user_id)
REFERENCES auth.user(user_id)
ON DELETE CASCADE;