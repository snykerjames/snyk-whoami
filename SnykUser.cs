using System;

namespace snyk_whoami {

    public class SnykUser
    {
        public string id { get; set; }
        public string username { get; set; }
        public string email { get; set; }

        public SnykOrgInfo [] orgs { get; set; }
    }

    public class SnykOrgInfo
    {
        public string name { get; set; }
        public string id { get; set; }
        public SnykGroupInfo group { get; set; }
    }

    public class SnykGroupInfo
    {
        public string name { get; set; }
        public string id { get; set; }
    }

}