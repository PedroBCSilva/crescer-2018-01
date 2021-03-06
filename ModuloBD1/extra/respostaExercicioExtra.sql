-- Exercicio 1
Select l.Municipio, AVG(l.Valor_Realizado)
from Licitacao l 
where l.Situacao='Normal' 
group by l.Municipio order by l.Municipio 
-- Exercicio 2
Select Projeto,Empresa_Licitante, Valor_Realizado, Esfera,
(CASE
WHEN Esfera='Municipal' then Valor_Realizado-Imposto_Municipal
WHEN Esfera='Estadual' then Valor_Realizado-Imposto_Estadual
WHEN Esfera='Federal' then Valor_Realizado-Imposto_Federal
END)
from Licitacao
-- Exercicio 3
Select l.Municipio, SUM(l.Imposto_Municipal) SomaImpostos
from Licitacao l
group by l.Municipio
order by SomaImpostos Desc
-- Exercicio 4
Select l.Projeto,(DATEDIFF(month,l.Data_Inicio_Prev,l.Data_Fim_Prev)) as MesesPrevisto, 
(DATEDIFF(month,l.Data_Inicio_Real,l.Data_Fim_Real)) as MesesReal
from Licitacao l
where l.Data_Inicio_Prev<>l.Data_Inicio_Real
order by  l.Projeto
-- Exercicio 5
Select Distinct l.Empresa_Licitante, round(sum(l.Valor_Realizado),2) as Faturamento, 
round(sum(l.Valor_Realizado)/sum(l.Profissionais),2) as MediaPorProfissional,
sum(l.Profissionais) as TotalProfissionais,
count(1) as TotalProjetos
from Licitacao l
where l.Situacao='Normal'
group by l.Empresa_Licitante
order by Faturamento desc
-- Exercicio 6
Select l.Projeto, l.Data_Inicio_Real, DATENAME(dw,l.Data_Inicio_Prev) 
from Licitacao l 
where DATEPART(dw,l.Data_Inicio_Prev)= 7 or DATEPART(dw,l.Data_Inicio_Prev)= 6;
-- Exercicio 7
Select  l.Empresa_Licitante, l.Faturamento_1Ano_Anterior,
(SUM(l.Valor_Previsto))
from Licitacao l
where 
(Select SUM(lin.Valor_Previsto) from Licitacao lin where lin.Empresa_Licitante=l.Empresa_Licitante) >= (l.Faturamento_1Ano_Anterior*1.5)
group by l.Empresa_Licitante,l.Faturamento_1Ano_Anterior
-- Exercicio 8
Select l.Projeto,l.Situacao,l.Valor_Previsto,l.Valor_Realizado
from Licitacao l 
where l.Identificador=17255
Union
Select l.Projeto,l.Situacao,l.Valor_Previsto,l.Valor_Realizado
from Licitacao l 
where l.Identificador=17120