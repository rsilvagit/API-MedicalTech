
# MedicalTech

Este projeto é uma Web API que executa o cadastro, atualização e exclusão de médicos , enfermeiros e pacientes para uma unidade de saúde.

A aplicação foi criada com o objetivo de facilitar o gerenciamento de pessoas dentro da unidade de saúde,  reduzindo o tempo de busca nos cadastros, verificando o status dos atendimento dos pacientes, a especialidade clínica dos médicos e registros dos enfermeiros, entre outras funcionalidades que facilitarão e melhorarão o desempenho de toda a equipe.

No desenvolvimento da Web API MedicalTech foi utilizada a linguagem de programação C# juntamente com o framework dotnet, por meio do packstage entity framework, que integra ao banco de dados SQL Server onde armazena seus metadados.

O sistema conta com rotas post, put, get e delete para as entidades médicos, pacientes e enfermeiros.

Exemplo:

Get /api/Enfermeiros

Post /api/Enfermeiros

Get /api/Enfermeiros{identificador}

Put api/Enfermeiros{identificador}

Delete api/Enfermeiros{identificador}

Get /api/Medicos

Post /api/Medicos

Get /api/Medicos{identificador}

Put api/Medicos{identificador}

Delete api/Medicos{identificador}

Get /api/Pacientes

Post /api/Pacientes

Get /api/Pacientes{identificador}

Put api/Pacientes{identificador}

Put api/Pacientes{identificador}/Status

Delete api/Pacientes{identificador}

Campos Obrigatórios:

Data de Nascimento: Obrigatório, data válida.(Deve ser informada no request no formato padrão ISO8601)

Contato de Emergência : tipo string, obrigatório para o cadastro dos pacientes.

Instituição de Ensinoi e Formação: tipo string, obrigatório para o cadstro de médicos.

Cadastro CRM/UF: tipo string obrigatório para o cadastro de médicos.

Especialização Clinica: tipo enum, obrigatório para o cadastro de médicos.
[tipos válidos: Clinico_Geral;Anestesista;Dermatologia;Ginecologia;Neurologia;Pediatria;Ortopedia.]

Instituição de Ensino e Formação: tipo string, obrigatório para o cadastro de enfermeiros.
COFEN/UF: tipo string, obrigatório para o cadstro de enfermeiros.

Requisitos
Antes de executar o projeto MedicalTech localmente, certifique-se de ter as seguintes ferramentas e bibliotecas instaladas em sua máquina:

.NET SDK: o SDK é necessário para compilar e executar o projeto.
Visual Studio ou VS Code: um IDE é recomendado para facilitar o desenvolvimento.
SQL Server Management Studio: para gerenciar o banco de dados SQL Server (utilizado pela aplicação).

Além disso, você deve ter conhecimento básico em C# e em desenvolvimento de aplicativos web usando o framework .NET.

Instalação
Para executar este projeto localmente em máquina você precisa clonar o repositório em https://github.com/rsilvagit/Coqueiros--Proj.-Avaliativo-Modulo-1.git. Utlize um compilador tal como Visual Studio ou VScode para abrir a solução. Além disso será necessário obter a aplicação de gerenciamento de banco de dados SQL Server. Para que a aplicação possa funcionar corretamente em sua máquina será necessário realizar a injeção de dependência com a connectionString correspondente ao seu servidor. Essa configuração poderá ser realizada na Program da aplicação, o DB deve permanecer com o nome indicado na aplicação conforme exemplo abaixo:

Exemplo: 

string connectionString = "Server=DESKTOP-9HO92VC\\SQLEXPRESS;Database=labmedicinebd;Trusted_Connection=True;TrustServerCertificate=True;";
builder.Services.AddDbContext<MedicalTechContext>(o => o.UseSqlServer(connectionString));
builder.Services.AddControllers(options =>
{
    options.ModelMetadataDetailsProviders.Add(new SystemTextJsonValidationMetadataProvider());
});

Após a correta configuração do Banco de Dados e connectionString  crie um database com o nome de labmedicinebd e após execute no prompt de comando dos pacotes nuget do seu projeto o comando Update-Database no Visual Studio ou dotnet ef database update no VScode para atualização do Database com as tabelas e dados iniciais do sistema.

Melhorias a serem implementadas nas próximas versões:
Validação de CPF;
Validação de CRM;
Validação de COFEN;
Controlador de tempo de espera do paciente;
Classificação de prioridade de atendimento;

Suporte:
rafael_silva49@estudante.sesisenai.org.br

Como Contribuir
Se você encontrou um bug ou tem uma sugestão para melhorar o projeto, sinta-se à vontade para enviar um email para rafael_silva49@estudante.sesisenai.org.br. Se você deseja contribuir com código, você pode fazer isso enviando um pull request. Para enviar um pull request, siga os seguintes passos:

Faça um fork do repositório
Crie uma nova branch com sua contribuição: git checkout -b minha-contribuicao
Faça as alterações necessárias e faça commit das mesmas: git commit -am 'Adiciona minha contribuição'
Faça o push da branch para o seu fork: git push origin minha-contribuicao

Abra um pull request no repositório original.

Agradecemos antecipadamente suas contribuições e feedbacks sobre o projeto MedicalTech!

Faça bom proveito deste projeto e quaisquer dúvidas ou sugestões entre em contato pelo e-mail rafael_silva49@estudante.sesisenai.org.br.

Por se tratar de um projeto em desenvolvimento, o uso deste software é de responsabilidade do usuário. O autor não se responsabiliza por quaisquer danos diretos ou indiretos decorrentes do mal uso deste software.


Att,

Rafael Silva
Link do video de apresentação do progeto.
https://drive.google.com/file/d/1R1V-FqmAE_b8bAv7AKFv2cTPHWhcPMEV/view?usp=share_link




