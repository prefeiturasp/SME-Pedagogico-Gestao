import styled from "styled-components";

export const LoaderWrapper = styled.div`
  width: 100%;
  height: 100%;
  position: absolute;
  z-index: 4;
  background-color: #fff;
  opacity: 50%;
`;

export const DivLoading = styled.div`
  top: 20%;
  left: 50%;
  position: absolute;
  z-index: 5;
  display: inline-grid;
  vertical-align: middle;
  align-items: center;
`;

export const SpinerLoading = styled.span`
 color: #1890ff !important;
 margin-bottom: 5px;
 margin-left: 25px;
`;

