import React from 'react'

function CardTestimonial(props) {
    return (
        <div className="cardTestimonial">
            <p className="headerCardTestimonial border-bottom">{props.devname} and {props.compname}</p>
            <p className="headerCardTestimonial border-bottom">{props.testimonial}</p>
            <p className="headerCardTestimonial">{props.devname}, {props.position}</p>
        </div>
        )
}

export default CardTestimonial