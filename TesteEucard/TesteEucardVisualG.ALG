Algoritmo "Novadson Thelus"
{Empresa   : Eucard
{Descri��o   : Aqui voc� descreve o que o programa faz! (fun��o)}
{Autor(a)    : Novadson Thelus}
{Data atual  : 18/11/2020}
Var
   {Matrizes e Vetor}
   transactions:vetor[1..2,1..3]de caractere
   payments:vetor[1..2,1..4] de caractere
   valortotal:vetor[1..1] de inteiro
   {Contador para la�o de repeti��o}
   i,j:inteiro
   {Variavel}
   valorRecebido:real
   valorTotalRecebido:real
   resposta:caractere
   {Essa variav�l deveria ser INTEIRO,mas usei CARACTERE por que A matriz CARACTERE}
   indentificador:caractere
Inicio
   {Iniciando variav�l com Zero}
   valorTotalRecebido <-0

   {Informa��o de Transactions}
   para i de 1 ate 1 faca
      {Valor da Transactions}
      escreva("Informe o valor da Transa��o",i,"�:")
      leia(valortotal[i])
      {Ser� verificado se o valor informado � maior que ZERO}
      se valortotal[i] > 0 entao
         {Transformar Real para Centavos}
         valortotal[i]<- valortotal[i]*100
         {Atribuindo metade da valor da transa��o para cada credor}
         valorRecebido <- valortotal[i]/2
      senao
         escreva("O valor informado deve ser maior que ZERO,por favor informe um valor maior que ZERO!:")
         leia(valortotal[i])
         {Transformar Real para Centavos}
         valortotal[i] <- valortotal[i]*100
         valorRecebido <- valortotal[i]/2
      fimse
      {Identificador}
      escreva("Informe o identificador �nico:")
      leia(transactions[i,2])
      {Data de Cria��o}
      escreva("Informe a data de Cria��o:")
      leia(transactions[i,3])
      {Informa��o de credores}
      para j  de 1 ate 2 faca
         escreva("Informe o nome do Credor",j,"�:")
         leia(payments[j,1])
         escreva("Informe o CNPJ do Credor",j,":")
         leia(payments[j,2])
         {Validar CNPJ}
         se compr(payments[j,2]) <> 14 entao
            escreval("O CNPJ deve conter 14 n�meros,informe o CNPJ do Credor",j,":")
            leia(payments[j,2])
         senao
            {N�O FAZ NADA}
         fimse
         payments[j,3] <- transactions[i,2]
      fimpara
   fimpara
   escreval("")
   escreva("Deseja rastrear a transa��o? S para sim N para N�o:")
   leia (resposta)
   escreval("")
   escreva("Informe o n�mero de indentificador:")
   escreval("")
   leia (indentificador)
   escolha resposta
   {Usando switch}
   caso "S"
      {Imprimir Lista de Transactions}
      para i de 1 ate 1 faca
         se transactions[i,2] = indentificador entao
            escreval("Valor da Transaction:",valortotal[i]," centavos","  Identificador:",transactions[i,2],"   Data de Cria�ao: ",transactions[i,3])
            escreval("-------------------------------------------------------------------------------------")
            {Imprimir Lista de Credores}
            para j de 1 ate 2 faca
               se  payments[j,3] = indentificador entao
                  valorTotalRecebido <-  valorTotalRecebido + valorRecebido
                  escreval("Nome do Credor:",payments[j,1]," CNPJ do Credor:",payments[j,2],"  Valor recebido do Credor:",valorRecebido," centavos","Identificador:",payments[j,3])
                  escreval("-------------------------------------------------------------------------------------")
               senao
                  {N�o faz nada}
               fimse
            fimpara
         senao
            {N�o faz nada}
         fimse
      fimpara
      {Imprimindo a soma dos valores recebido por credor}
      escreval("A soma dos valores recebido por credor:",valorTotalRecebido," centavos")
   caso "N"
      escreval ("Obrigado pela transa��o")
   outrocaso
      escreval ("N�o foi poss�vel rastrear a transa��o.")
   fimescolha
Fimalgoritmo
