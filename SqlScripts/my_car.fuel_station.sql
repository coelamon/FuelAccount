-- Table: my_car.fuel_station

-- DROP TABLE my_car.fuel_station;

CREATE TABLE my_car.fuel_station
(
    fuel_station_id integer NOT NULL DEFAULT nextval('my_car.fuel_station_id_seq'::regclass),
    name character varying(40) COLLATE pg_catalog."default" NOT NULL,
    address character varying COLLATE pg_catalog."default",
    CONSTRAINT fuel_station_pkey PRIMARY KEY (fuel_station_id)
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE my_car.fuel_station
    OWNER to postgres;
