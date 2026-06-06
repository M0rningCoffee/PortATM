drop database if exists atm;
create database atm;
use atm;

create table contas
(
	id_conta int auto_increment,
	cpf varchar(14) not null,
	saldo decimal default 0,
	cartao varchar(16) not null,
	data_nasc varchar(10) not null,
	nome_completo varchar(100) not null,
	pin int(6) not null,
	agencia varchar(6) not null,
	cc varchar(7) not null,
	pix bool default true,
	primary key (id_conta)
);


create table registros
(
	id_registros int auto_increment,
	data timestamp,
	id_conta_to int not null, 
	id_conta_from int not null,
	operacao varchar(64) check(operacao = "pix" or operacao = "transferência" or operacao = "saque" or operacao = "depósito"),
	valor decimal default 0,
	primary key (id_registros),
	foreign key (id_conta_to) references contas(id_conta),
	foreign key (id_conta_from) references contas(id_conta)
);



insert into contas(cpf, cartao, data_nasc, nome_completo, pin, agencia, cc) 
values ("111.111.111-11", "1111222233334444", "2006-12-12", "Pedro Vinicius", 123456, "1111-1", "11111-1");

insert into registros(id_conta_to, id_conta_from, operacao, valor)
values (1, 1, "depósito", 0);

insert into registros(id_conta_to, id_conta_from, operacao, valor)
values (1, 1, "dinheiro", 10);

select * from contas;
update contas set saldo = 10000 where id_conta = 1; 
select saldo from contas where id_conta = 1;
select * from registros;


