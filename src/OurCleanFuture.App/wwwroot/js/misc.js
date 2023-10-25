function isTestEnvironment() {
    const hostname = window.location.hostname;
    return hostname.includes("ourcleanfuture-test") || hostname.includes("localhost");
}
