import React, { Component } from 'react';
import Footer from './Footer';
import RegisterButton from './RegisterBtn';
import CardTestimonial from './CardsTestimonial';
import { Link } from 'react-router-dom';

export class Home extends Component {
  static displayName = Home.name;

    render() {
        const testimonials1 = [
            {
                id: 1,
                userImage: "https://randomuser.me/api/portraits/thumb/men/75.jpg",
                devname: 'Robert',
                compname: 'CodeStar',
                text: 'I never imagined that I could find a position so quickly and practically as it was using merge me. From the first contact with the recruiter until starting the work day.',
                position: 'Cloud Engineer'
            },
            {
                id: 2,
                userImage: "https://randomuser.me/api/portraits/thumb/women/75.jpg",
                devname: 'Ellie',
                compname: 'Rising',
                text: 'The search process for a position is much simpler and more practical compared to conventional means.In addition, it is possible to find any vacancy here, which is wonderful.',
                position: 'Front-End Developer'
            },

        ];

        const testimonials2 = [
            {
                id: 3,
                userImage: "https://randomuser.me/api/portraits/thumb/men/20.jpg",
                devname: 'Viktor',
                compname: 'iZiFinance',
                text: 'I was looking for something that would make me evolve so I found a Full-Stack vacancy which was essential for my growth and I found it within Merge Me, in a simple and fast way.',
                position: 'Full-Stack Engineer'
            },
            {
                id: 4,
                userImage: "https://randomuser.me/api/portraits/thumb/women/23.jpg",
                devname: 'Anna',
                compname: 'Cloud Rising',
                text: 'Contact with the recruiter became much simpler, faster and more practical in every way. Even the job search just got a whole lot simpler. Job descriptions here are pretty straight forward.',
                position: 'C# Developer'
            },
        ];

        const testimonials3 = [
            {
                id: 5,
                userImage: "https://randomuser.me/api/portraits/thumb/women/57.jpg",
                devname: 'Lisa',
                compname: 'MilesKen Inc',
                text: 'I never imagined that I could find a position so quickly and practically as it was using merge me. From the first contact with the recruiter until starting the work day.',
                position: 'Haskell Developer'
            },
            {
                id: 6,
                userImage: "https://randomuser.me/api/portraits/thumb/men/5.jpg",
                devname: 'Lucas',
                compname: 'Dellaware Software',
                text: 'I never imagined that I could find a position so quickly and practically as it was using merge me. From the first contact with the recruiter until starting the work day.',
                position: 'Back-End Developer'
            },
        ];
    return (
        <div>
            <section className="dsp-grid-center mb-80">
                <h1 className="createAccountTxt">Send your pull request </h1>
                <h1 className="getMerged">and get merged!</h1>
                <p className="hookText">
                    You can look for developer position as you can look for developer being a head hunter or recruiter.
                </p>
                <div>
                    <Link to="/signup">
                        <RegisterButton register="signup" registerstyle="registerDeveloper" />
                    </Link>
                </div>
            </section>
            <section className="mt-15">
                <div className="container">
                    <div className="row">
                        <div className="col-4">
                            {testimonials1.map((testimonials1) =>
                                <div className="pb-10" key={testimonials1.id}>
                                    <CardTestimonial
                                        userImage={testimonials1.userImage}
                                        devname={testimonials1.devname}
                                        compname={testimonials1.compname}
                                        testimonial={testimonials1.text}
                                        position={testimonials1.position} />
                                </div>
                            )}
                        </div>
                        <div className="col-4">
                            {testimonials2.map((testimonials2) =>
                                <div className="pb-10" key={testimonials2.id}>
                                    <CardTestimonial
                                        userImage={testimonials2.userImage}
                                        devname={testimonials2.devname}
                                        compname={testimonials2.compname}
                                        testimonial={testimonials2.text}
                                        position={testimonials2.position} />
                                </div>
                            )}
                        </div>
                        <div className="col-4">
                            {testimonials3.map((testimonials3) =>
                                <div className="pb-10" key={testimonials3.id}>
                                    <CardTestimonial
                                        userImage={testimonials3.userImage}
                                        devname={testimonials3.devname}
                                        compname={testimonials3.compname}
                                        testimonial={testimonials3.text}
                                        position={testimonials3.position} />
                                </div>
                            )}
                        </div>
                    </div>
                </div>
            </section>
            <Footer />
      </div>
    );
  }
}
