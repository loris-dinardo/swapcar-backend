-- type: INSERT
-- user: LD
-- created: 22/3/2019

-- USER
INSERT INTO auth.user VALUES ( 1,'user1@swapcar.ch', 'nick_user_1', 'hash_pwd', 'salt_pwd', '2019-03-10 12:30:00');
INSERT INTO auth.user VALUES ( 2,'user2@swapcar.ch', 'nick_user_2', 'hash_pwd', 'salt_pwd', '2019-03-11 12:30:00');
INSERT INTO auth.user VALUES ( 3,'user3@swapcar.ch', 'nick_user_3', 'hash_pwd', 'salt_pwd', '2019-03-12 12:30:00');
INSERT INTO auth.user VALUES ( 4,'user4@swapcar.ch', 'nick_user_4', 'hash_pwd', 'salt_pwd', '2019-03-13 12:30:00');

-- PROFIL
INSERT INTO auth.profile VALUES ( 1,'fname_user_1', 'fname_user_1', 1);
INSERT INTO auth.profile VALUES ( 2,'fname_user_2', 'fname_user_2', 2);
INSERT INTO auth.profile VALUES ( 3,'fname_user_3', 'fname_user_3', 3);
INSERT INTO auth.profile VALUES ( 4,'fname_user_4', 'fname_user_4', 4);

-- UPDATE SEQUENCE
SELECT setval('auth.user_seq', (SELECT MAX(user_id) FROM auth.user));
SELECT setval('auth.profile_seq', (SELECT MAX(profile_id) FROM auth.profile));


