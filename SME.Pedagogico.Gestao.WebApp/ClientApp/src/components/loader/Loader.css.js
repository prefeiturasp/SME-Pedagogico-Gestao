import styled from "styled-components";

export const LoaderWrapper = styled.div`
  width: 100%;
  height: 100%;
  position: absolute;
  z-index: 29;
  background-color: #fff;
  opacity: 50%;
`;

export const DivLoading = styled.div`
  top: ${({ isPrinting }) => isPrinting ? "35%" : "20%"};
  left: 50%;
  position: absolute;
  z-index: 30;
  display: inline-grid;
  vertical-align: middle;
  align-items: center;
`;

export const SpinerLoading = styled.span`
 color: #1890ff !important;
 margin-bottom: 5px;
 margin-left: 25px;
`;

export const ButtonClose = styled.button `
  position: absolute;
  right: 0;
  font-size: 24px;

  &:focus {
    box-shadow: none;
  }
 
  &:hover {
    opacity: 0.6;
  }

`;