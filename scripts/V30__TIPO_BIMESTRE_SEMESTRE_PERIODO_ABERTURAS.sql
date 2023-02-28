alter table public."PeriodoDeAberturas" add column if not exists "TipoPeriodicidade" int4 default 2 not null;
INSERT INTO public."PeriodoDeAberturas"
("Ano", "Bimestre", "DataInicio", "DataFim", "TipoPeriodicidade")
VALUES('2023', 1, '2023-03-01 00:00:00.000', '2023-03-31 00:00:00.000', 1);
INSERT INTO public."PeriodoDeAberturas"
("Ano", "Bimestre", "DataInicio", "DataFim", "TipoPeriodicidade")
VALUES('2023', 2, '2023-08-01 00:00:00.000', '2023-08-31 00:00:00.000', 1);
