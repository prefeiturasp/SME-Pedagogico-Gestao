import styled from 'styled-components';

export const MessageWrapper = styled.div`
  display: flex;
  flex-direction: column;
`;

export const ButtonDownload = styled.a`
  height: 100%;
  color: white;
  background: rgb(6, 79, 121);
  border-radius: 2.5px;
  padding: 15px;
  margin-top: 5px;
  width: 115px;

  &:hover {
    text-decoration: none;
    color: #fff;
  }
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