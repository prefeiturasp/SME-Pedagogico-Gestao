import styled from "styled-components";

export const CorpoRelatorio = styled.div`
  .overflow-hidden {
    overflow: hidden;
  }

  .item-celula {
    overflow: hidden;
    display: block;
    text-overflow: ellipsis;
    white-space: nowrap;
  }

  .primeira-linha {
    flex: 0 0 8.333333%;
    white-space: nowrap;
  }

  .segunda-linha {
    width: 100%;
    padding: 0 15px;
  }

  .celulas-fixas {
    position: absolute;
    z-index: 99;
    background: white;
    width: 30%;
    }
  }

  .celulas-variaveis {
    margin-left: 31.2%;
    width: 68.8%;
  }

  .tamanho-celula {
    padding: 0 15px;
    width: 100%;
    min-width: 135px;
    justify-content: center;
  }
`;
