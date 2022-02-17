drop table car,person;

create table person(
	id uuid DEFAULT uuid_generate_v4() not null PRIMARY KEY ,
	first_name varchar(50) not null,
	last_name varchar(50) not null
);

create table car(
 	id bigserial not null primary key,
	name varchar(50) not null,
	price numeric(19,2) not null,
	person_id uuid references person (id),
	unique(person_id)
);



insert into car(name,price) values ('land rover','20000'),('gmc','30000.5');
insert into person(first_name,last_name) values ('justin','chien'),('hengi','chien');
-- insert into person(first_name,last_name,car_id) values ('justin1','chien1',1),('hengi2','chien2',2);
--  insert into person(first_name,last_name,car_id) values ('justin4','chien4',4);
-- select * from car;
-- select * from person;


--create table with uuid(uuid-ossp extension)
-- SELECT uuid_generate_v4();

CREATE TABLE contacts (
    contact_id uuid DEFAULT uuid_generate_v4() not null PRIMARY KEY ,
    first_name VARCHAR NOT NULL,
    last_name VARCHAR NOT NULL,
    email VARCHAR NOT NULL,
    phone VARCHAR
);

-- INSERT INTO contacts (
--     first_name,
--     last_name,
--     email,
--     phone
-- )
-- VALUES
--     (
--         'John',
--         'Smith',
--         'john.smith@example.com',
--         '408-237-2345'
--     ),
--     (
--         'Jane',
--         'Smith',
--         'jane.smith@example.com',
--         '408-237-2344'
--     ),
--     (
--         'Alex',
--         'Smith',
--         'alex.smith@example.com',
--         '408-237-2343'
--     );
	
-- SELECT
--     *
-- FROM
--     contacts;