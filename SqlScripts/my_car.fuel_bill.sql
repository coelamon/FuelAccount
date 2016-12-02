-- Table: my_car.fuel_bill

-- DROP TABLE my_car.fuel_bill;

CREATE TABLE my_car.fuel_bill
(
    fuel_bill_id integer NOT NULL DEFAULT nextval('my_car.fuel_bill_id_seq'::regclass),
    bill_date date NOT NULL,
	bill_time time without time zone,
    fuel_id integer NOT NULL,
    fuel_station_id integer,
    fuel_price real NOT NULL,
    litres real NOT NULL,
    discount real,
    kilometrage real,
    payment numeric(18, 2),
    CONSTRAINT fuel_bill_pkey PRIMARY KEY (fuel_bill_id),
    CONSTRAINT fuel_bill_to_fuel_fkey FOREIGN KEY (fuel_id)
        REFERENCES my_car.fuel (fuel_id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    CONSTRAINT fuel_bill_to_fuel_station_fkey FOREIGN KEY (fuel_station_id)
        REFERENCES my_car.fuel_station (fuel_station_id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE my_car.fuel_bill
    OWNER to postgres;

-- Index: fki_fuel_bill_to_fuel_fkey

-- DROP INDEX my_car.fki_fuel_bill_to_fuel_fkey;

CREATE INDEX fki_fuel_bill_to_fuel_fkey
    ON my_car.fuel_bill USING btree
    (fuel_id)
    TABLESPACE pg_default;

-- Index: fki_fuel_bill_to_fuel_station_fkey

-- DROP INDEX my_car.fki_fuel_bill_to_fuel_station_fkey;

CREATE INDEX fki_fuel_bill_to_fuel_station_fkey
    ON my_car.fuel_bill USING btree
    (fuel_station_id)
    TABLESPACE pg_default;
