using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloCadastro.Enum.Usuario.Perfil
{
    public enum Permissao
    {
        // ========================
        // USUÁRIOS / ACESSO
        // ========================
        USUARIO_VISUALIZAR = 1,
        USUARIO_CRIAR = 2,
        USUARIO_EDITAR = 3,
        USUARIO_EXCLUIR = 4,

        // ========================
        // VENDAS
        // ========================
        VENDAS_VISUALIZAR = 100,
        VENDAS_CRIAR = 101,
        VENDAS_EDITAR = 102,
        VENDAS_CANCELAR = 103,

        // ========================
        // FINANCEIRO
        // ========================
        FINANCEIRO_VISUALIZAR = 200,
        FINANCEIRO_LANCAR = 201,
        FINANCEIRO_BAIXAR = 202,
        FINANCEIRO_ESTORNAR = 203,

        // ========================
        // ESTOQUE
        // ========================
        ESTOQUE_VISUALIZAR = 300,
        ESTOQUE_MOVIMENTAR = 301,
        ESTOQUE_AJUSTAR = 302,

        // ========================
        // RELATÓRIOS
        // ========================
        RELATORIO_VENDAS = 400,
        RELATORIO_FINANCEIRO = 401,
        RELATORIO_GERENCIAL = 402,
        RELATORIO_RESULTADO = 403,

        // ========================
        // RH
        // ========================
        RH_VISUALIZAR = 500,
        RH_ADMITIR = 501,
        RH_DEMITIR = 502,

        // ========================
        // GESTÃO EMPRESARIAL
        // ========================
        GESTAO_VISUALIZAR = 600,
        GESTAO_INDICADORES = 601,

        // ========================
        // CONFIGURAÇÕES
        // ========================
        CONFIGURACAO_SISTEMA = 700
    }
}
