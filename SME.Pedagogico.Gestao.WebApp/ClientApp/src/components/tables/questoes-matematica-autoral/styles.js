import { Table } from "antd";
import styled from "styled-components";
import { COLORS } from "../colors";

export const TableContainer = styled(Table)`
  border-radius: 0;

  .ant-table-content table > thead.ant-table-thead {
    th {
      background-color: ${COLORS.HEADER.PURPLE_BACKGROUND};
      color: white;
    }
  }

  .ant-table-wrapper .ant-table-container {
    table thead tr th {
      border-start-start-radius: 0px !important;
      border-start-end-radius: 0px !important;
    }
  }

  tr.ant-table-row td {
    padding: 0px;
  }

  .ant-table {
    margin-block: 0 !important;
    margin-inline: 0 !important;
  }
`;

export const RowTableContainer = styled(Table)`
  .ant-table-content table > thead.ant-table-thead th {
    background-color: ${COLORS.HEADER.GRAY_BACKGROUND};
    color: ${COLORS.LABEL};
  }
`;

export const Title = styled.div`
  display: flex;
  justify-content: space-between;

  span {
    gap: 8px;
    display: flex;
    align-items: center;
  }
`;
