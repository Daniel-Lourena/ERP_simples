# EVITAR.md

Registro de práticas que geraram retrabalho em sessões anteriores. Consultar antes de planejar qualquer operação de médio/grande porte.

---

## Escopo e Planejamento

- **Plano incompleto:** sempre mapear todos os consumidores antes de iniciar (ex: ao renomear namespaces, listar Entity + Service + ViewModel + Forms + Testes + Migrations de uma vez, não descobrir reativamente pelo build)
- **Sessão muito longa:** refatorações estruturais grandes devem ser divididas em etapas com commit e build verde ao final de cada uma; sessões longas esgotam contexto e perdem detalhes
- **Escopo crescente no meio da execução:** se o escopo expandir durante a tarefa, parar, replanejar e confirmar com o usuário antes de continuar

## Shell e Automação (Windows)

- **`python3` não disponível:** não tentar usar `python3` inline — não está no PATH neste ambiente
- **PowerShell inline via bash:** heredoc bash interpreta `\r\n` como literais, corrompendo arquivos; sempre escrever scripts `.ps1` via `Write` e executar com `powershell.exe -ExecutionPolicy Bypass -File script.ps1`
- **Validar substituição em massa em um arquivo antes de aplicar em lote:** evita corromper dezenas de arquivos de uma vez

## Build e Verificação

- **Não acumular mudanças sem compilar:** o ciclo correto é alterar → compilar → corrigir → avançar; nunca empilhar todas as camadas para compilar só no final
- **FQNs hardcoded não são detectados pelo compilador:** após renomear namespaces, buscar ativamente por `NomeAntigo.Namespace` nos arquivos consumidores
- **Migrations Designer usam strings FQN:** `*.Designer.cs` e `ModelSnapshot.cs` referenciam tipos como strings — não são detectados pelo compilador; atualizar manualmente junto com o namespace da entidade
- **Validar Migrations contra banco real:** após atualizar o Snapshot, rodar `dotnet ef migrations list` para confirmar que o EF Core não detecta mudança de modelo espúria

## Qualidade do Código Gerado

- **Não adicionar todos os sub-namespaces a todos os arquivos:** adicionar apenas os `using` que o arquivo realmente precisa; a abordagem "adicionar tudo em todos" cria ruído e dívida técnica
- **Verificar `.claude/settings.local.json`:** modificações nesse arquivo durante a sessão não devem ser commitadas sem revisão; avaliar se o conteúdo é pessoal ou deve ser versionado
