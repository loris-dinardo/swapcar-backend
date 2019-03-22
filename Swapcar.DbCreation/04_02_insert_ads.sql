-- type: INSERT
-- user: LD
-- created: 22/3/2019

-- ADS
INSERT INTO ads.ads(ads_id, user_id, sell_id, title, image_uri, advert_from, advert_to, creation_date) 
VALUES ( 1,4,3, 'Ma super voiture', 'ressources/ads/ad_1.png', '2019-03-13 16:00:00', '2019-03-23 12:00:00', '2019-03-13 12:00:00');

INSERT INTO ads.ads(ads_id, user_id, trade_in_id, title, image_uri, advert_from, advert_to,creation_date) 
VALUES ( 2,1,1, 'Mon super echange', 'ressources/ads/ad_2.png', '2019-03-13 16:00:00', '2019-03-23 12:00:00', '2019-03-13 12:00:00');

-- UPDATE SEQUENCE
SELECT setval('ads.ads_seq', (SELECT MAX(ads_id) FROM ads.ads));


