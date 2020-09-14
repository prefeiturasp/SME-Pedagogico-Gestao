import React from 'react';
import { Button, Form, FormGroup, Label, Input, FormText } from 'reactstrap';

// import { Container } from './styles';

function RadioButtonGroup({ lista, valor }) {
    return (
        <>
            <FormGroup check className="align-content-center">
                <Label check>
                    <Input type="radio" name="radio1" />
                </Label>
            </FormGroup>
        </>);
}

export default RadioButtonGroup;