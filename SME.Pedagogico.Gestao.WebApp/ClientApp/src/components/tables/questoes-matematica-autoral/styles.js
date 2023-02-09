import { Table } from "antd";
import styled from "styled-components";
import { COLORS } from "../colors";

export const TableContainer = styled(Table)`
  color: ${COLORS.LABEL};

  .ant-table-header {
    display: none;
  }

  tr.ant-table-row {
    height: 50px;

    td {
      padding: 0px;
      height: inherit;

      label > div.ant-form-item {
        display: flex;
        margin-bottom: 0;
        align-items: center;
        justify-content: center;
      }
    }
  }

  tr.ant-table-row .ant-table {
    margin-block: 0 !important;
    margin-inline: 0 !important;
  }
`;

export const PerguntaContainer = styled.div`
  padding: 16px;
  font-weight: 500;
  background-color: ${COLORS.HEADER.GRAY_BACKGROUND};
`;

export const RespostaContainer = styled.div`
  padding: 16px;
`;

export const NumeroChamadaTexto = styled.div`
  height: 100%;
  display: flex;
  padding: 16px;
  font-weight: 700;
  align-items: center;
  justify-content: center;
  background-color: ${COLORS.HEADER.LIGHT_GRAY_BACKGROUND};

  &:hover {
    background-color: ${COLORS.HEADER.BACKGROUND_HOVER};
  }
`;

export const TableHeader = styled.div`
  display: flex;
  font-size: 14px;
  font-weight: 700;
  background-color: ${COLORS.HEADER.PURPLE_BACKGROUND};

  > div:first-child {
    width: 500px;
    border-right: 1px solid white;
    justify-content: center;
  }

  > div:last-child {
    flex-grow: 1;
    justify-content: space-between;

    span {
      grid-gap: 8px;
      display: flex;
      font-size: 12px;
      font-weight: 500;
      align-items: center;
    }
  }
`;

export const TableColumn = styled.div`
  color: white;
  display: flex;
  padding: 16px;
  align-items: center;
`;
