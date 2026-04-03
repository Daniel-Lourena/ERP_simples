# SKILL_COMMIT

Quando o usuário solicitar `/commit` ou pedir para rodar esse skill, executar os passos abaixo **sem pedir confirmação adicional**.

---

## Passos obrigatórios

### 1. Verificar estado do repositório

Rodar em paralelo:
- `git status` — ver arquivos modificados e não rastreados
- `git diff` — ver todas as mudanças staged e unstaged
- `git log --oneline -5` — ver os últimos commits para seguir o estilo de mensagem

### 2. Analisar as mudanças

- Identificar o tipo: `feat`, `fix`, `docs`, `refactor`, `test`, `chore`
- Redigir mensagem de commit concisa (1 linha título + corpo opcional)
- Focar no **porquê**, não no **o quê**
- Seguir o estilo dos commits anteriores do repositório

### 3. Staged dos arquivos relevantes

- Adicionar apenas arquivos relacionados à mudança (nunca `git add -A` sem revisão)
- Nunca incluir `.env`, credenciais, binários desnecessários ou arquivos gerados

### 4. Commitar com co-autoria

Sempre incluir a linha de co-autoria no commit:

```bash
git commit -m "$(cat <<'EOF'
<tipo>: <mensagem resumida>

<corpo opcional explicando o porquê>

Co-Authored-By: Claude Sonnet 4.6 <noreply@anthropic.com>
EOF
)"
```

### 5. Confirmar sucesso

Rodar `git status` após o commit para verificar que está limpo.

---

## Regras

- **Nunca** usar `--no-verify`, `--amend` (salvo pedido explícito) ou `git add -A` sem revisão
- **Nunca** fazer push automaticamente — apenas commitar localmente
- Se não houver mudanças (`git status` limpo), informar o usuário e não criar commit vazio
- Se houver arquivos em conflito, reportar ao usuário antes de prosseguir
