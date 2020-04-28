import React from "react";
import { Route, Redirect } from "react-router-dom";
import { connect } from "react-redux";
import Dashboard from "../components/navigation/Dashboard";
import { ROLES_ENUM } from "../Enums";

const AuthenticatedDashboardProfileRoute = ({ component: C, user, ...rest }) => {
  return (
    <Route
      {...rest}
      render={props => {

        if (
          user.isAuthenticated &&
          (ROLES_ENUM.EditarEConsultar(user.activeRole.roleName) || 
          ROLES_ENUM.ApenasConsultas(user.activeRole.roleName))
        ) {
          return (
            <Dashboard>
              <C />
            </Dashboard>
          );
        } else if (
          user.isAuthenticated &&
          ROLES_ENUM.ApenasRelatorios(user.activeRole.roleName)
        ) {
          return <Redirect to={`/Relatorios/Sondagem`} />;
        } else if (!user.isAuthenticated)  {
          return (
            <Redirect
              to={`/Login?redirect=${props.location.pathname}${
                props.location.search
              }`}
            />
          );
        }
      }}
    />
  );
};

export default connect(state => ({ user: state.user }))(
  AuthenticatedDashboardProfileRoute
);
