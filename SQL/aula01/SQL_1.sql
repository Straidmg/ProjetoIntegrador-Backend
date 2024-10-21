select * From world.country;
select code, name, population from world.country;
select * from world.city;
select * from sakila.film;

select * from world.country where continent = "Europe";
select * from world.country where population > 1000000;
select * from world.country where Continent = "Europe" and population > 100000;
select * from world.country where code = "bra";

select * from world.country where continent = "Europe" and population > 100000 order by population;

select * from world.countrylanguage;

select * from sakila.category;
insert into sakila.category(category_id, name)
values (17, "Terror");