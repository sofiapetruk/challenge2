

# Challenge

## Integrantes do Grupo

| Nome            |   RM   | Sala   |
|:----------------|:------:|:-------|
| Julia Monteiro  | 557023 | 2TDSPV |
| Victor Henrique | 556206 | 2TDSPH |
| Sofia Petruk    | 556585 | 2TDSPV |


### Solução do projeto

    O projeto propõe o desenvolvimento de uma plataforma inteligente para gestão de pátios da Mottu, integrando visão computacional, sensores IoT e QR Code.
    Com câmeras 360° instaladas no local, o sistema identificará visualmente motos em tempo real, mesmo sem placa ou com chassi oculto. Cada moto terá um QR Code 
    vinculado ao seu cadastro completo, incluindo imagem, modelo e status. A plataforma permitirá a localização rápida dos veículos, rastreabilidade de movimentações 
    e histórico de manutenções, eliminando perdas internas e aumentando a eficiência operacional. A solução visa resolver um dos principais gargalos logísticos da empresa 
    com precisão e escalabilidade

### Descrição do projeto

    Até o final do ano, o projeto contará com todas as funcionalidades propostas na solução. Por enquanto, foram criadas as classes básicas necessárias para dar início ao desenvolvimento.
    Criamos a classe do usuário, que servirá para login e cadastro, mas também permitirá acompanhar o status da própria moto ou realizar a compra de uma nova.
    Também desenvolvemos uma classe exclusiva para a moto, que será utilizada para identificá-la no pátio e registrar o que precisa ser feito nela.

## Como Rodar o Projeto

### Clonar repositorio

    https://github.com/sofiapetruk/challenge2.git

### Abra o projeto no Visual Studio:

    Inicie o Visual Code

    Vá em Arquivo > Open... e selecione a pasta do projeto clonado

   


### Execute os seguintes no terminal:

    1.  cd challenge2
    2. dotnet restore
    3. dotnet run


### Endponits do projeto
| Método | Endpoint                  | Descrição                                                       |
|--------|---------------------------|-----------------------------------------------------------------|
| POST   | [api/usuarios]            |     Cria um novo usuario                                        |
 | POST  | [api//usuarios/login]     | Cria um login e verifica se é o mesmo email e senha do cadastro |
| GET    | [api/usuarios]            | Retorna todos os usuarios que tem no db                         |
| GET    | [api/usuarios/{idUsuario}]| Retorna somente um usuario                                      |
| PUT    | [api/usuarios/{idUsuario}]| Atualiza o usuario com id especifico                            |
| DELETE | [api/usuarios/{idUsuario}]| Delete o usuario com o id especifico                            |

| Método | Endpoint                | Descrição                            |
|--------|-------------------------|--------------------------------------|
| POST   | [api/motos]             | Cria uma nova mota                   |
| GET    | [api/moto]              | Retorna todos as motos que tem no db |
| GET    | [api/motos/{idMoto}]    | Retorna somente uma moto             |
| PUT    | [api/motos/{idMoto}]    | Atualiza a moto com id especifico    |
| DELETE | [/motos/{idMoto}] )     | Delete a moto com o id especifico    |
|SWAGGER| ((https://localhost:7012/swagger/index.html))| Verificar quais atributos temos que utilizar na nossa api|
