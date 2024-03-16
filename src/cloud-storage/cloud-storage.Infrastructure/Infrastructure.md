<h1>Domain Driven Design</h1>
</br>

<h2>Infrastructure</h2>

A responsabilidade do projeto no DDD é conter as implementações do código que de fato executa a lógica de negócio,
no nosso caso, ele vai conter a implementação do cóodigo que vai concetar com a API do Google, que conectaria com um banco de dados,
envia Email, envia SMS, etc...

Essa classe é responsável por executar toda a implementação, colcoar a mão na massa, por exemplo, essa camada seria responsável por
executar a lógica das ações, comunicar com fontes externas (exemplo: Api e Database)