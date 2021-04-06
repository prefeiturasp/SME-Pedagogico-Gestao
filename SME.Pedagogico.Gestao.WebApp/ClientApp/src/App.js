import React, { Component } from "react";
import "./App.css";
import { Route, Switch } from "react-router-dom";
import UnauthenticatedRoute from "./routes/UnauthenticatedRoute";
import AuthenticatedDashboardProfileRoute from "./routes/AuthenticatedDashboardProfileRoute";
import Login from "./components/login/Login";
import AutenticacaoSgp from "./components/sgp/autenticacaoSgp";
import Dashboard from "./components/navigation/Dashboard";

export default class App extends Component {
  static displayName = App.name;

  render() {
    return (
      <Switch>
        <UnauthenticatedRoute path="/Login" exact component={Login} />
        <Route path="/sgp" exact component={AutenticacaoSgp} />
        <AuthenticatedDashboardProfileRoute path="/" component={Dashboard} />
      </Switch>
    );
  }
}
