CREATE SEQUENCE my_car.fuel_bill_id_seq
    INCREMENT 1
    START 13
    MINVALUE 1
    MAXVALUE 9223372036854775807
    CACHE 1;

ALTER SEQUENCE my_car.fuel_bill_id_seq
    OWNER TO postgres;
