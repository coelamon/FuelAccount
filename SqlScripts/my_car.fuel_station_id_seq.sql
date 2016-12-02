CREATE SEQUENCE my_car.fuel_station_id_seq
    INCREMENT 1
    START 5
    MINVALUE 1
    MAXVALUE 9223372036854775807
    CACHE 1;

ALTER SEQUENCE my_car.fuel_station_id_seq
    OWNER TO postgres;
