import styled from "styled-components";
import Loader from "../loader/Loader";

export const CustomLoader = styled(Loader)`
  display: flex;
  justify-content: center;
  align-items: center;

  div {
    position: relative;
    top: 0;
    left: 0;
  }
`;
