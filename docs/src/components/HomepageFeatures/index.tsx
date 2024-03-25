import clsx from "clsx";
import Heading from "@theme/Heading";
import styles from "./styles.module.css";

type FeatureItem = {
  title: string;
  Svg: React.ComponentType<React.ComponentProps<"svg">>;
  description: JSX.Element;
};

const FeatureList: FeatureItem[] = [
  {
    title: "Covers All Your Needs",
    Svg: require("@site/static/img/undraw_docusaurus_mountain.svg").default,
    description: (
      <>
        This client supports all the free endpoints provided by the GoCardless
        API (Token, Institutions, Agreements, Requisitions and Accounts).
      </>
    ),
  },
  {
    title: "Easy to Use",
    Svg: require("@site/static/img/undraw_docusaurus_tree.svg").default,
    description: (
      <>
        All data returned by the API is returned as strongly typed objects, even
        errors. Acquiring and refreshing the authentication tokens required to
        use the API is handled automatically for you, without you having to
        worry about it.
      </>
    ),
  },
  {
    title: "Free and Open Source",
    Svg: require("@site/static/img/undraw_docusaurus_react.svg").default,
    description: (
      <>
        The client is MIT licensed and you can find the code on{" "}
        <a href="https://github.com/RobinTTY/NordigenApiClient">GitHub</a>. As
        long as the GoCardless API stays free, you'll be able to retrieve all
        your bank account data without paying one cent.
      </>
    ),
  },
];

function Feature({ title, Svg, description }: FeatureItem) {
  return (
    <div className={clsx("col col--4")}>
      <div className="text--center">
        <Svg className={styles.featureSvg} role="img" />
      </div>
      <div className="text--center padding-horiz--md">
        <Heading as="h3">{title}</Heading>
        <p>{description}</p>
      </div>
    </div>
  );
}

export default function HomepageFeatures(): JSX.Element {
  return (
    <section className={styles.features}>
      <div className="container">
        <div className="row">
          {FeatureList.map((props, idx) => (
            <Feature key={idx} {...props} />
          ))}
        </div>
      </div>
    </section>
  );
}
