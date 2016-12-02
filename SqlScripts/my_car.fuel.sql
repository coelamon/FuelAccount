-- Table: my_car.fuel

-- DROP TABLE my_car.fuel;

CREATE TABLE my_car.fuel
(
    fuel_id integer NOT NULL DEFAULT nextval('my_car.fuel_id_seq'::regclass),
    name character varying(40) COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT fuel_pkey PRIMARY KEY (fuel_id)
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE my_car.fuel
    OWNER to postgres;
