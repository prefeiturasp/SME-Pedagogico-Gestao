import React from "react";
import PropTypes from "prop-types";
import { LoaderWrapper, DivLoading, SpinerLoading } from "./Loader.css";

function Loader({ children, loading }) {
  return (
    <div>
      {loading ? (
        <LoaderWrapper>
          <DivLoading>
            <SpinerLoading className="spinner-border" role="status" />
            <span>Carregando...</span>
          </DivLoading>
        </LoaderWrapper>
      ) : null}
      {children}
    </div>
  );
}

Loader.propTypes = {
  children: PropTypes.oneOfType([
    PropTypes.node,
    PropTypes.any,
    PropTypes.symbol,
  ]),
  loading: PropTypes.bool,
  tip: PropTypes.string,
  ignorarTip: PropTypes.bool,
  className: PropTypes.string,
};

Loader.defaultProps = {
  loading: false,
  children: () => {},
  tip: "Carregando...",
  className: "",
  ignorarTip: false,
};

export default Loader;
