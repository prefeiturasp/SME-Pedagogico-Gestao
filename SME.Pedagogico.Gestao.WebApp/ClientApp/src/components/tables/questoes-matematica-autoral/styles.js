import { Table } from "antd";
import styled from "styled-components";
import { COLORS } from "../colors";

export const TableContainer = styled(Table)`
  .ant-table-container table > thead.ant-table-thead th {
    color: white;
    background-color: ${COLORS.HEADER.PURPLE_BACKGROUND};
  }

  .ant-table-wrapper table thead.ant-table-thead tr th.ant-table-cell {
    border-start-start-radius: 0px !important;
    border-start-end-radius: 0px !important;
  }

  tr.ant-table-row td {
    padding: 0px;
  }

  .ant-table {
    margin-block: 0 !important;
    margin-inline: 0 !important;
  }

  .ant-tooltip-inner {
    color: black;
  }
`;

export const RowTableContainer = styled(Table)`
  .ant-table-content table > thead.ant-table-thead th {
    background-color: ${COLORS.HEADER.GRAY_BACKGROUND};
    color: ${COLORS.LABEL};
  }

  .ant-table-tbody tr > td {
    padding: 16px;
  }

  .ant-table-content table > thead.ant-table-thead th {
    padding: 0;
    background-color: ${COLORS.HEADER.LIGHT_GRAY_BACKGROUND};

    &:hover {
      background-color: ${COLORS.HEADER.BACKGROUND_HOVER};
    }
  }
`;

export const Title = styled.div`
  font-weight: 700;

  &.flex {
    display: flex;
    justify-content: space-between;
  }

  span {
    gap: 8px;
    display: flex;
    font-weight: 500;
    align-items: center;
  }
`;

export const NumeroChamadaTexto = styled.div`
  padding: 16px;
`;
