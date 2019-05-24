import React, { Component } from 'react';
import './App.css';
import { Route, Switch } from 'react-router-dom';
import UnauthenticatedRoute from './routes/UnauthenticatedRoute';
import AuthenticatedDashboardRoute from './routes/AuthenticatedDashboardRoute';
import Login from './components/login/Login';
import Home from './components/home/Home';
import ClassPlan from './components/classRecord/ClassPlan';
import AnnualPlan from './components/classRecord/AnnualPlan';
import CyclePlan from './components/classRecord/CyclePlan';
import Poll from './components/classRecord/Poll';
import PollReport from './components/reports/PollReport';
import Documents from './components/classRecord/Documents';
import NotFound from './components/navigation/NotFound';

export default class App extends Component {
    static displayName = App.name;

    render() {
        return (
            <Switch>
                <UnauthenticatedRoute path="/Login" exact component={Login} />
                {/*<AuthenticatedDashboardRoute path="/" exact component={Home} />
                    <AuthenticatedDashboardRoute path="/RegistroDeClasse/PlanoDeAula" exact component={ClassPlan} />
                    <AuthenticatedDashboardRoute path="/RegistroDeClasse/PlanoAnual" exact component={AnnualPlan} />
                    <AuthenticatedDashboardRoute path="/RegistroDeClasse/PlanoDeCiclo" exact component={CyclePlan} />
                    <AuthenticatedDashboardRoute path="/RegistroDeClasse/Sondagem" exact component={Poll} />
                    <AuthenticatedDashboardRoute path="/RegistroDeClasse/Documentos" exact component={Documents} />*/}
                <AuthenticatedDashboardRoute path="/" exact component={Poll} />
                <AuthenticatedDashboardRoute path="/Relatorios/Sondagem" exact component={PollReport} />
                <Route component={NotFound} />
            </Switch>
        );
    }
}