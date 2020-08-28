import React, { useState, useEffect } from 'react'

export default function SondagemMatematicaAutoral() {
    const [estado, setEstado] = useState();

    useEffect(() => {
        setEstado("Ola Caique");
    }, [])

    return (
        <div>
            {estado}
        </div>
    )
}
