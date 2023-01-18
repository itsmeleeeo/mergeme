import React, { Component } from 'react';
import Footer from './Footer';
import RegisterButton from './RegisterBtn';
import CardTestimonial from './CardsTestimonial';
import { Link } from 'react-router-dom';

export class Home extends Component {
  static displayName = Home.name;

    render() {
        const testimonials = [
            {
                id: 1,
                devname: 'Robert',
                compname: 'CodeStar',
                text: 'I never imagined that I could find a position so quickly and practically as it was using merge me. From the first contact with the recruiter until starting the work day.',
                position: 'Cloud Engineer'
            },
            {
                id: 2,
                devname: 'Ellie',
                compname: 'Rising',
                text: 'The search process for a position is much simpler and more practical compared to conventional means.In addition, it is possible to find any vacancy here, which is wonderful.',
                position: 'Front-End Developer'
            },
            {
                id: 3,
                devname: 'Viktor',
                compname: 'iZiFinance',
                text: 'I was looking for something that would make me evolve so I found a Full-Stack vacancy which was essential for my growth and I found it within Merge Me, in a simple and fast way.',
                position: 'Full-Stack Engineer'
            },
            {
                id: 4,
                devname: 'Anna',
                compname: 'Cloud Rising',
                text: 'Contact with the recruiter became much simpler, faster and more practical in every way. Even the job search just got a whole lot simpler. Job descriptions here are pretty straight forward.',
                position: 'C# Developer'
            },
            {
                id: 5,
                devname: 'Lisa',
                compname: 'MilesKen Inc',
                text: 'I never imagined that I could find a position so quickly and practically as it was using merge me. From the first contact with the recruiter until starting the work day.',
                position: 'Haskell Developer'
            },
            {
                id: 6,
                devname: 'Lucas',
                compname: 'Dellaware Software',
                text: 'I never imagined that I could find a position so quickly and practically as it was using merge me. From the first contact with the recruiter until starting the work day.',
                position: 'Back-End Developer'
            },
        ];
    return (
        <div>
            <section className="dsp-grid-center sectionHeight">
                <h1 className="createAccountTxt">Send your pull request and get merged!</h1>
                <p className="footer text-center">
                    You can look for developer position as you can look for developer being a head hunter or recruiter.
                </p>
                <div className="dsp-flex mt-15">
                    <RegisterButton tag={Link} to="/developer" register="I am Developer!" registerstyle="registerDeveloper" />
                    <RegisterButton register="I am Recruiter!" registerstyle="registerRecruiter"/>
                </div>
            </section>
            <section className="testimonial">
                <h1 className="testimonialTxt">Testimonials</h1>
                <div className="col-lg-12 col-md-12 col-sm-12 mb-10">
                    {testimonials.map((testimonials) =>
                        <div className="pb-10" key={testimonials.id}>
                            <CardTestimonial
                                devname={testimonials.devname}
                                compname={testimonials.compname}
                                testimonial={testimonials.text}
                                position={testimonials.position} />
                        </div>
                        )}
                </div>
            </section>
            <Footer />
      </div>
    );
  }
}
