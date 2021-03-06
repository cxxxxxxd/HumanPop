import React from 'react'
import { Route, Switch, Redirect } from 'react-router-dom';
import Humans from '../containers/humans/humans.jsx';
import NewHuman from '../containers/newHuman/newHuman.jsx';
import EditHuman from '../containers/editHuman/editHuman.jsx';

export default class Routing extends React.Component {
    render() {
        return(
            <main>
                <Switch>
                    <Route path="/humans/edit" component={EditHuman} />
                    <Route path="/humans/new" component={NewHuman} />
                    <Route path="/humans" component={Humans} />
                    
                    <Route exact path="/" render={() => (<Redirect to="/humans" />)} />                   
                </Switch>
            </main>
        );
    }
}