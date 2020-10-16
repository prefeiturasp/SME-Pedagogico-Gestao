import styled from 'styled-components';
import { Link } from "react-router-dom";

export const MessageWrapper = styled.div`
  display: flex;
  flex-direction: column;
`;

export const ButtonDownload = styled(Link)`
  height: 100%;
  color: white;
  background: rgb(6, 79, 121);
  border-radius: 2.5px;
  padding: 15px;
  margin-top: 5px;
  width: 115px;
`;

export const ButtonClose = styled.button `
  position: absolute;
  top: 0;
  right: 0;
  font-size: 24px;

  &:focus {
    box-shadow: none;
  }
 
  &:hover {
    opacity: 0.6;
  }
`;